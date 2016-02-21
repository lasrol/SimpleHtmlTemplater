using System;

namespace SimpleHtmlTemplater
{

    public interface IConverterContainer
    {
        void RegisterConverter(Type type, IConverter handler);
        IConverter GetConverter(Type type);
    }
}
