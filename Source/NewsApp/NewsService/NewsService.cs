using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace NewsService
{
    public class NewsService
    {
        private static readonly Random NewsRandom = new Random();

        public async Task<List<Article>> GetArticles()
        {
            return await GetArticles(10);
        }

        public async Task<List<Article>> GetArticles(int numberOfArticle)
        {
            // async to simulate a web service call
            var result = await Task.Run(() =>
            {
                var articles = new List<Article>();
                for (var i = 0; i < numberOfArticle; i++)
                {
                    articles.Add(ArticleGenerator());
                }
                return articles;
            });

            return result;
        }

        private static Article ArticleGenerator()
        {
            var paras = new List<string>();
            for (var i = 0; i < NewsRandom.Next(5, 15); i++)
            {
                paras.Add(ArticleText.GetParagraph());
            }
            return new Article
            {
                Headline = ArticleText.GetHeader(),
                Paragraphs = paras,
                Image = new BitmapImage(new Uri($"ms-appx:///NewsService/Images/PreviewImage{NewsRandom.Next(1, 21):D2}.png"))
            };
        }
    }
}