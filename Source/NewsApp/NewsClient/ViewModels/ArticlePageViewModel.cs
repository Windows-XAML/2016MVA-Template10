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
using NewsClient.Services.DataService;

namespace NewsClient.ViewModels
{
    public class ArticlePageViewModel : ViewModelBase
    {
        private DataService _dataService;

        public ArticlePageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                Article = DataService.Sample();
            }
            else
            {
                _dataService = new DataService();
            }
        }

        #region properties

        private Article _article;
        public Article Article { get { return _article; } set { Set(ref _article, value); } }

        #endregion

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            if (parameter is int)
            {
                var articleId = (int)parameter;
                Article = await _dataService.GetArticleAsync(articleId);
            }

            if (Article == null)
            {
                HandleMissingArticle();
            }
            else
            {
                UpdateIsFavorite();
            }
        }

        private async void HandleMissingArticle()
        {
            await new ContentDialog
            {
                Title = "News App",
                Content = "Article is missing",
                PrimaryButtonText = "Ok"
            }.ShowAsync();
            NavigationService.GoBack();
        }

        #region Favorites

        public async void UpdateIsFavorite()
        {
            var favorites = await _dataService.GetFavoritesAsync();
            IsFavorite = favorites.Any(x => x.Id.Equals(Article?.Id));
            RaisePropertyChanged(nameof(IsFavorite));
        }

        public bool IsFavorite { get; set; }

        public async void AddToFavorites()
        {
            await _dataService.AddToFavoritesAsync(Article);
            UpdateIsFavorite();
        }

        public async void RemoveFromFavorites()
        {
            await _dataService.RemoveFromFavoritesAsync(Article);
            UpdateIsFavorite();
        }

        #endregion
    }
}

