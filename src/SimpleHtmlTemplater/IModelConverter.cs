using System.Collections.Generic;

namespace SimpleHtmlTemplater
{
    public interface IModelConverter
    {
        IDictionary<string, string> Convert(object obj);
    }
}
