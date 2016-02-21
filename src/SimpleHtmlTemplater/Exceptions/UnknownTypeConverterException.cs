using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleHtmlTemplater.Exceptions
{
    public class UnknownTypeConverterException
        : Exception
    {
        public Type Type { get; set; }
        public override string Message => $"Could not find any converter for {Type}";
    }
}
