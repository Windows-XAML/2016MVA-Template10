using Template10.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System;
using System.Collections.ObjectModel;

namespace NewsClient.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                for (int i = 0; i < 10; i++)
                {
                    Items.Add(new NewsService.Article
                    {
                        Headline = "Article headline",
                        Paragraphs = new[]
                        {
                            "The quick brown fox jumps over the lazy dog.",
                            "Now is the time for all good men to come the aid of their country.",
                        }.ToList()
                    });
                }
            }
        }

        #region properties

        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object>();

        string _Item = string.Empty;
        public string Item { get { return _Item; } set { Set(ref _Item, Item); } }

        string _FilterString = string.Empty;
        public string FilterString { get { return _FilterString; } set { Set(ref _FilterString, FilterString); } }

        #endregion

        #region methods

        public void Filter() { }

        public void View() { }

        #endregion

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (state.Any())
            {
                FilterString = state[nameof(FilterString)]?.ToString();
                Filter();
                state.Clear();
            }
            return Task.CompletedTask;
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            if (suspending)
            {
                state[nameof(FilterString)] = FilterString;
            }
            return Task.CompletedTask;
        }

        public override Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            return Task.CompletedTask;
        }

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}

