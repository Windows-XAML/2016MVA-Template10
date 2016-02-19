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

namespace NewsClient.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        NewsService.NewsService _NewsService;

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
            else
            {
                _NewsService = new NewsService.NewsService();
            }
        }

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

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            // restore filter string, if any
            if (suspensionState.ContainsKey(nameof(FilterString)))
            {
                FilterString = suspensionState[nameof(FilterString)]?.ToString();
            }

            // load articles
            if (SessionState.ContainsKey(nameof(NewsService.NewsService)))
            {
                _originalItems = SessionState.Get<List<Article>>(nameof(NewsService.NewsService));
            }
            else
            {
                _originalItems = await _NewsService.GetCachedArticlesAsync();
                SessionState.Add(nameof(NewsService.NewsService), _originalItems);
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

