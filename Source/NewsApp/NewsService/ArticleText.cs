using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsService
{
    internal static class ArticleText
    {
        private static readonly List<string> Lines = new List<string>(); 
        private static Random ArticleRandom = new Random();

        static ArticleText()
        {
            Lines.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            Lines.Add("Integer nec odio.");
            Lines.Add("Praesent libero.");
            Lines.Add("Sed cursus ante dapibus diam.");
            Lines.Add("Sed nisi.");
            Lines.Add("Nulla quis sem at nibh elementum imperdiet.");
            Lines.Add("Duis sagittis ipsum.");
            Lines.Add("Praesent mauris.");
            Lines.Add("Fusce nec tellus sed augue semper porta.");
            Lines.Add("Mauris massa.");
            Lines.Add("Vestibulum lacinia arcu eget nulla.");
            Lines.Add("Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.");
            Lines.Add("Curabitur sodales ligula in libero.");
            Lines.Add("Sed dignissim lacinia nunc.");
            Lines.Add("Curabitur tortor.");
            Lines.Add("Pellentesque nibh.");
            Lines.Add("Aenean quam.");
            Lines.Add("In scelerisque sem at dolor.");
            Lines.Add("Maecenas mattis.");
            Lines.Add("Sed convallis tristique sem.");
            Lines.Add("Proin ut ligula vel nunc egestas porttitor.");
            Lines.Add("Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa.");
            Lines.Add("Fusce ac turpis quis ligula lacinia aliquet.");
            Lines.Add("Mauris ipsum.");
            Lines.Add("Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh.");
            Lines.Add("Quisque volutpat condimentum velit.");
            Lines.Add("Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.");
            Lines.Add("Nam nec ante.");
            Lines.Add("Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis.");
            Lines.Add("Nulla facilisi.");
            Lines.Add("Ut fringilla.");
            Lines.Add("Suspendisse potenti.");
            Lines.Add("Nunc feugiat mi a tellus consequat imperdiet.");
            Lines.Add("Vestibulum sapien.");
            Lines.Add("Proin quam.");
            Lines.Add("Etiam ultrices.");
            Lines.Add("Suspendisse in justo eu magna luctus suscipit.");
            Lines.Add("Sed lectus.");
            Lines.Add("Integer euismod lacus luctus magna.");
            Lines.Add("Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam.");
            Lines.Add("Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui.");
            Lines.Add("Praesent blandit dolor.");
            Lines.Add("Sed non quam.");
            Lines.Add("In vel mi sit amet augue congue elementum.");
            Lines.Add("Morbi in ipsum sit amet pede facilisis laoreet.");
            Lines.Add("Donec lacus nunc, viverra nec, blandit vel, egestas et, augue.");
            Lines.Add("Vestibulum tincidunt malesuada tellus.");
            Lines.Add("Ut ultrices ultrices enim.");
            Lines.Add("Curabitur sit amet mauris.");
            Lines.Add("Morbi in dui quis est pulvinar ullamcorper.");
            Lines.Add("Nulla facilisi.");
            Lines.Add("Integer lacinia sollicitudin massa.");
            Lines.Add("Cras metus.");
            Lines.Add("Sed aliquet risus a tortor.");
            Lines.Add("Integer id quam.");
            Lines.Add("Morbi mi.");
            Lines.Add("Quisque nisl felis, venenatis tristique, dignissim in, ultrices sit amet, augue.");
            Lines.Add("Proin sodales libero eget ante.");
            Lines.Add("Nulla quam.");
            Lines.Add("Aenean laoreet.");
            Lines.Add("Vestibulum nisi lectus, commodo ac, facilisis ac, ultricies eu, pede.");
            Lines.Add("Ut orci risus, accumsan porttitor, cursus quis, aliquet eget, justo.");
            Lines.Add("Sed pretium blandit orci.");
            Lines.Add("Ut eu diam at pede suscipit sodales.");
            Lines.Add("Aenean lectus elit, fermentum non, convallis id, sagittis at, neque.");
            Lines.Add("Nullam mauris orci, aliquet et, iaculis et, viverra vitae, ligula.");
            Lines.Add("Nulla ut felis in purus aliquam imperdiet.");
            Lines.Add("Maecenas aliquet mollis lectus.");
            Lines.Add("Vivamus consectetuer risus et tortor.");
            Lines.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            Lines.Add("Integer nec odio.");
            Lines.Add("Praesent libero.");
            Lines.Add("Sed cursus ante dapibus diam.");
            Lines.Add("Sed nisi.");
            Lines.Add("Nulla quis sem at nibh elementum imperdiet.");
            Lines.Add("Duis sagittis ipsum.");
            Lines.Add("Praesent mauris.");
            Lines.Add("Fusce nec tellus sed augue semper porta.");
            Lines.Add("Mauris massa.");
            Lines.Add("Vestibulum lacinia arcu eget nulla.");
            Lines.Add("Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.");
            Lines.Add("Curabitur sodales ligula in libero.");
            Lines.Add("Sed dignissim lacinia nunc.");
            Lines.Add("Curabitur tortor.");
            Lines.Add("Pellentesque nibh.");
            Lines.Add("Aenean quam.");
            Lines.Add("In scelerisque sem at dolor.");
            Lines.Add("Maecenas mattis.");
            Lines.Add("Sed convallis tristique sem.");
            Lines.Add("Proin ut ligula vel nunc egestas porttitor.");
            Lines.Add("Morbi lectus risus, iaculis vel, suscipit quis, luctus non, massa.");
            Lines.Add("Fusce ac turpis quis ligula lacinia aliquet.");
            Lines.Add("Mauris ipsum.");
            Lines.Add("Nulla metus metus, ullamcorper vel, tincidunt sed, euismod in, nibh.");
            Lines.Add("Quisque volutpat condimentum velit.");
            Lines.Add("Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.");
            Lines.Add("Nam nec ante.");
            Lines.Add("Sed lacinia, urna non tincidunt mattis, tortor neque adipiscing diam, a cursus ipsum ante quis turpis.");
            Lines.Add("Nulla facilisi.");
            Lines.Add("Ut fringilla.");
            Lines.Add("Suspendisse potenti.");
            Lines.Add("Nunc feugiat mi a tellus consequat imperdiet.");
            Lines.Add("Vestibulum sapien.");
            Lines.Add("Proin quam.");
            Lines.Add("Etiam ultrices.");
            Lines.Add("Suspendisse in justo eu magna luctus suscipit.");
            Lines.Add("Sed lectus.");
            Lines.Add("Integer euismod lacus luctus magna.");
            Lines.Add("Quisque cursus, metus vitae pharetra auctor, sem massa mattis sem, at interdum magna augue eget diam.");
            Lines.Add("Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Morbi lacinia molestie dui.");
            Lines.Add("Praesent blandit dolor.");
            Lines.Add("Sed non quam.");
            Lines.Add("In vel mi sit amet augue congue elementum.");
            Lines.Add("Morbi in ipsum sit amet pede facilisis laoreet.");
            Lines.Add("Donec lacus nunc, viverra nec, blandit vel, egestas et, augue.");
            Lines.Add("Vestibulum tincidunt malesuada tellus.");
            Lines.Add("Ut ultrices ultrices enim.");
            Lines.Add("Curabitur sit amet mauris.");
            Lines.Add("Morbi in dui quis est pulvinar ullamcorper.");
            Lines.Add("Nulla facilisi.");
            Lines.Add("Integer lacinia sollicitudin massa.");
            Lines.Add("Cras metus.");
            Lines.Add("Sed aliquet risus a tortor.");
            Lines.Add("Integer id quam.");
            Lines.Add("Morbi mi.");
            Lines.Add("Quisque nisl felis, venenatis tristique, dignissim in, ultrices sit amet, augue.");
            Lines.Add("Proin sodales libero eget ante.");
            Lines.Add("Nulla quam.");
            Lines.Add("Aenean laoreet.");
            Lines.Add("Vestibulum nisi lectus, commodo ac, facilisis ac, ultricies eu, pede.");
            Lines.Add("Ut orci risus, accumsan porttitor, cursus quis, aliquet eget, justo.");
            Lines.Add("Sed pretium blandit orci.");
            Lines.Add("Ut eu diam at pede suscipit sodales.");
            Lines.Add("Aenean lectus elit, fermentum non, convallis id, sagittis at, neque.");
        }

        public static string GetHeader()
        {
            return Lines[ArticleRandom.Next(0, Lines.Count)];
        }

        public static string GetParagraph()
        {
            var start = ArticleRandom.Next(0, Lines.Count);
            var end = ArticleRandom.Next(start, Lines.Count);
            var sb = new StringBuilder();
            var first = true;
            for (int i = start; i < end; i++)
            {
                sb.AppendLine($"{(first ? string.Empty : " ")}{Lines[i]}");
                if (first) first = false;
            }

            return sb.ToString();
        }
    }
}
