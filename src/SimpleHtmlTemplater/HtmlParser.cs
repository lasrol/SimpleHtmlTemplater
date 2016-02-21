using System.Collections.Generic;

namespace SimpleHtmlTemplater
{
    public class HtmlParser
    {
        private readonly string _html;
        public HtmlParser(string html)
        {
            _html = html;
        }

        public string Parse(IDictionary<string,string> replaceWith)
        {
            var result = _html;
            foreach (var p in replaceWith)
            {
                result = result.Replace($"{{{p.Key}}}", p.Value);
            }
            return result;
        }
    }
}
