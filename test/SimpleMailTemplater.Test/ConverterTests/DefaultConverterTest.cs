using System.Globalization;
using System.Threading;
using FluentAssertions;
using SimpleHtmlTemplater.Converters;
using Xunit;

namespace SimpleHtmlTemplater.Test.ConverterTests
{
    public class DefaultConverterTest
    {
        public DefaultConverterTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [Theory]
        [InlineData(1,"1")]
        [InlineData("test","test")]
        [InlineData(1.2d,"1.2")]
        public void CheckingAllBasicValues(object value, string expected)
        {
            var sut = new DefaultConverter();
            var result = sut.Convert(value);
            result.Should().Be(expected);
        }
    }
}
