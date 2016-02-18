using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Newtonsoft.Json;

namespace NewsService
{
    public class NewsService
    {
        private static readonly Random NewsRandom = new Random();

        public async Task<List<Article>> GetArticlesAsync()
        {
            var result = await GetArticlesAsync(20);
            return new List<Article>(result);
        }

        public async Task<List<Article>> GetArticlesAsync(int numberOfArticle)
        {
            // async to simulate a web service call
            var result = await Task.Run(() =>
            {
                var articles = new List<Article>();
                for (var i = 0; i < numberOfArticle; i++)
                {
                    var article = ArticleGenerator();
                    article.Id = i;
                    articles.Add(article);
                }
                return articles;
            });

            return result;
        }

        public async Task<List<Article>> GetCachedArticlesAsync()
        {
            // async to simulate a web service call
            var data = await CachedArticlesAsync();
            var result = await Task.Run(() => JsonConvert.DeserializeObject<List<Article>>(data));

            return result;
        }


        private static Article ArticleGenerator()
        {
            var paras = new List<string>();
            for (var i = 0; i < NewsRandom.Next(5, 15); i++)
            {
                paras.Add(ArticleText.GetParagraph());
            }
            var image = $"ms-appx:///NewsService/Images/PreviewImage{NewsRandom.Next(1, 21):D2}.png";
            return new Article
            {
                Headline = ArticleText.GetHeader(),
                Paragraphs = paras,
                Image = image,
            };
        }

        private static async Task<string> CachedArticlesAsync()
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///NewsService/Data/Data.json"));
            return await FileIO.ReadTextAsync(file);
        }
    }
}