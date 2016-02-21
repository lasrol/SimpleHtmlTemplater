using System;
using System.Collections.Generic;
using SimpleHtmlTemplater.Converters;

namespace SimpleHtmlTemplater
{
    public class ConverterContainer : IConverterContainer
    {
        private readonly IDictionary<string, IConverter> _container;

        public ConverterContainer()
        {
            _container = new Dictionary<string, IConverter>();
        }
        public void RegisterConverter(Type type, IConverter handler)
        {
            if (_container.ContainsKey(type.FullName))
            {
                _container[type.FullName] = handler;
            }
            else
            {
                _container.Add(type.FullName, handler);
            }
        }

        public IConverter GetConverter(Type type)
        {
            if (_container.ContainsKey(type.FullName))
            {
                return _container[type.FullName];
            }

            return new DefaultConverter();
        }
    }
}
