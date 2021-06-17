using System.Threading.Tasks;
using System.Linq;
using AngleSharp;

namespace Awesome
{
    public static class NewsParser
    {
        public static async Task<string> FindNews(string text)
        {
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            var document = await context.OpenAsync($"https://dtf.ru/search/v2/content/new?query={text}");
            var elements = document.QuerySelectorAll("div.content-title.content-title--short.l-island-a");
            var arr = elements.Select(it => it.TextContent).Take(5);
            return string.Join('\n', arr);
        }
    }
}