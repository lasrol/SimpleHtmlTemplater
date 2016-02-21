using System.IO;
using System.Text;

namespace SimpleHtmlTemplater
{
    public class Templater : ITemplater
    {
        private readonly IModelConverter _modelConverter;
        private readonly StringBuilder _htmlContent = new StringBuilder();

        public Templater(IModelConverter modelConverter)
        {
            _modelConverter = modelConverter;
        }

        public ITemplater AddTemplate(string content)
        {
            _htmlContent.Append(content);
            return this;
        }

        public ITemplater AddTemplateFromFile(string path)
        {
            AddTemplate(Readfile(path));
            return this;
        }

        public ITemplater AddTemplateFromFile(string path, object model)
        {
            AddTemplate(Readfile(path), model);
            return this;
        }

        public ITemplater AddTemplate(string content, object model)
        {
            var templateHtml = content;
            var dictonary = _modelConverter.Convert(model);
            foreach (var d in dictonary)
            {
                templateHtml = templateHtml.Replace($"{{{d.Key}}}", d.Value);
            }
            _htmlContent.Append(templateHtml);
            return this;
        }

        private string Readfile(string path)
        {
            return File.ReadAllText(path);
        }

        public string Build()
        {
            return _htmlContent.ToString();
        }

    }
}

