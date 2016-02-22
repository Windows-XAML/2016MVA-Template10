using NewsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Common;

namespace NewsClient.Services.DataService
{
    public class DataService
    {
        FileHelper _fileHelper;
        List<Article> _favorites;
        NewsService.NewsService _newsService;

        public DataService()
        {
            if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                _fileHelper = new FileHelper();
                _newsService = new NewsService.NewsService();
            }
        }

        private static List<Article> _articles;
        public async Task<List<Article>> GetArticlesAsync()
        {
            if (_articles == null)
                _articles = await _newsService.GetCachedArticlesAsync();
            if (_articles == null)
                _articles = new List<Article>();
            return _articles;
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            return (await GetArticlesAsync()).FirstOrDefault(x => x.Id.Equals(id));
        }

        #region favorites

        public static event EventHandler<List<Article>> FavoritesChanged;

        public async Task<List<Article>> GetFavoritesAsync()
        {
            if (_favorites == null)
                _favorites = await _fileHelper.ReadFileAsync<List<Article>>(nameof(_favorites));
            if (_favorites == null)
                _favorites = new List<Article>();
            return _favorites;
        }

        public async Task<List<Article>> AddToFavoritesAsync(Article article)
        {
            var favorites = await GetFavoritesAsync();
            favorites.RemoveAll(x => x.Id.Equals(article.Id));
            favorites.Add(article);
            return await SaveFavoritesAsync(favorites);
        }

        public async Task<List<Article>> RemoveFromFavoritesAsync(Article article)
        {
            var favorites = await GetFavoritesAsync();
            favorites.RemoveAll(x => x.Id.Equals(article.Id));
            return await SaveFavoritesAsync(favorites);
        }

        async Task<List<Article>> SaveFavoritesAsync(List<Article> favorites)
        {
            if (await _fileHelper.WriteFileAsync(nameof(_favorites), favorites))
                _favorites = favorites;
            else
                throw new Exception("Failed to save.");
            FavoritesChanged?.Invoke(this, _favorites);
            return _favorites;
        }

        #endregion

        public static Article Sample(object headline = null)
        {
            return new Article
            {
                Headline = $"Article{headline} headline",
                Paragraphs = new[]
                        {
                        "The quick brown fox jumps over the lazy dog.",
                        "Now is the time for all good men to come the aid of their country.",
                    }.ToList()
            };
        }
    }
}
