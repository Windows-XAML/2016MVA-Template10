using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsService
{
    public class Article
    {
        public string Headline { get; set; }

        public List<string> Paragraphs { get; set; }

        public string FirstParagraph => Paragraphs[0];

        public List<string> RemainingParagraphs => Paragraphs.GetRange(1, Paragraphs.Count - 1);
    }
}
