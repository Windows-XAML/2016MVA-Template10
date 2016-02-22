using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace NewsService
{
    public class Article
    {
        public int Id { get; set; }

        public string Headline { get; set; }

        public List<string> Paragraphs { get; set; }

        [JsonIgnore]
        public string FirstParagraph => Paragraphs[0];

        [JsonIgnore]
        public List<string> RemainingParagraphs => Paragraphs.GetRange(1, Paragraphs.Count - 1);

        public string Image { get; set; }
    }
}
