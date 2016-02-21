using FluentAssertions;
using SimpleHtmlTemplater.Converters;
using Xunit;

namespace SimpleHtmlTemplater.Test
{
    public class ConverterContainerTest
    {
        [Fact]
        public void UseDefaultConverterIfNotInCollection()
        {
            var sut = new ConverterContainer();
            var result = sut.GetConverter(typeof(string));
            result.GetType().Should().Be(typeof(DefaultConverter));
        }
    }
}
