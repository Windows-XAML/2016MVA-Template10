using Template10.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System;
using System.Collections.ObjectModel;
using Windows.Storage;
using NewsService;
using Newtonsoft.Json;
using Template10.Utils;
using NewsClient.Services.DataService;

namespace NewsClient.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private DataService _dataService;

        public MainPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                Enumerable.Range(1, 10).ForEach(x => Items.Add(DataService.Sample(x)));
            }
            else
            {
                _dataService = new DataService();
            }
        }

        #region properties

        private List<NewsService.Article> _originalItems;

        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object>();

        public NewsService.Article Item
        {
            get { return null; }
            set
            {
                if (value != null)
                    NavigationService.Navigate(typeof(Views.ArticlePage), value.Id);
                RaisePropertyChanged();
            }
        }

        string _FilterString = string.Empty;
        public string FilterString { get { return _FilterString; } set { Set(ref _FilterString, value); } }

        #endregion

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            // load articles
            _originalItems = await _dataService.GetArticlesAsync();

            // restore filter string, if any
            if (suspensionState.ContainsKey(nameof(FilterString)))
            {
                FilterString = suspensionState[nameof(FilterString)]?.ToString();
            }
            else if (parameter as string != null)
            {
                FilterString = parameter?.ToString();
            }

            // apply initial filter
            Filter();
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(FilterString)] = FilterString;
            }
            return Task.CompletedTask;
        }

        public void Filter()
        {
            var filter = _originalItems.Where(x => x.Headline.ToLower().Contains(FilterString?.ToLower()));
            Items.AddRange(filter, true);
        }

        public void GotoSettings() =>
          NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}

