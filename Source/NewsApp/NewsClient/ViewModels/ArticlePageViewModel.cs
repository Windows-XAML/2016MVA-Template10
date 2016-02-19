using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Template10.Common;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using NewsService;

namespace NewsClient.ViewModels
{
    public class ArticlePageViewModel : ViewModelBase
    {
        private Article _currentArticle;
        public ArticlePageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                Article = new NewsService.Article
                {
                    Headline = "Article headline",
                    Paragraphs = new[]
                    {
                        "The quick brown fox jumps over the lazy dog.",
                        "Now is the time for all good men to come the aid of their country.",
                    }.ToList()
                };
            }
        }

        private Article _article;
        public Article Article { get { return _article; } set { Set(ref _article, value); } }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (parameter == null)
            {
                HandleMissingArticle();
                return;
            }

            if (!(parameter is int))
            {
                HandleMissingArticle();
                return;
            }

            var articleId = (int)parameter;

            List<Article> originalItems;
            if (SessionState.ContainsKey(nameof(NewsService.NewsService)))
            {
                originalItems = SessionState.Get<List<Article>>(nameof(NewsService.NewsService));
            }
            else
            {
                originalItems = await new NewsService.NewsService().GetCachedArticlesAsync();
                SessionState.Add(nameof(NewsService.NewsService), originalItems);
            }
            Article = originalItems.SingleOrDefault(a => a.Id == articleId);
            if (Article == null)
            {
                HandleMissingArticle();
            }
        }

        private async void HandleMissingArticle()
        {
            await new ContentDialog { Title = "News App", Content = "Article is missing", PrimaryButtonText = "Ok" }.ShowAsync();
            NavigationService.GoBack();
        }
    }
}

