using System.Collections.Generic;
using System.Reflection;
using SimpleHtmlTemplater.Exceptions;

namespace SimpleHtmlTemplater
{
    public class ModelConverter : IModelConverter
    {
        private readonly IConverterContainer _container;

        public ModelConverter(IConverterContainer container)
        {
            _container = container;
        }

        public IDictionary<string, string> Convert(object obj)
        {
            var convertedModel = new Dictionary<string, string>();
            var modelProperties = obj.GetType().GetProperties();
            foreach (var prop in modelProperties)
            {
                var converter = _container.GetConverter(prop.PropertyType);
                if (converter == null) { throw new UnknownTypeConverterException() {Type = prop.PropertyType }; }

                convertedModel.Add(prop.Name, converter.Convert(prop.GetValue(obj, null)));
            }
            return convertedModel;
        }
    }
}
