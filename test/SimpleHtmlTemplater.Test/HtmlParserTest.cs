using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace SimpleHtmlTemplater.Test
{
    public class HtmlParserTest
    {
        public Dictionary<string, string> SetupModelDictionary()
        {
            return new Dictionary<string, string>()
            {
                { "Variable", "test" },
                { "Var123", "123" },
                { "MyVar", "Me" },
                {"test", "and"},
                {"Variable6", "works"},
                {"multi", "Multiple"}
            };
        }
        [Theory]
        [InlineData("<p>This is a {Variable}</p>", "<p>This is a test</p>")]
        [InlineData("<div>This is a {Variable}<p>{Var123}</p><span>{MyVar}</span> {Variable}</div>", "<div>This is a test<p>123</p><span>Me</span> test</div>")]
        [InlineData("this is a {Variable} {test} {Variable6}. With {multi}", "this is a test and works. With Multiple")]
        public void ReplaceVariables(string line, string expected)
        {
            int actual = 0;
            var sut = new HtmlParser(line);
            var result = sut.Parse(SetupModelDictionary());
            result.Should().Be(expected);
        }

        [Fact]
        public void InputEmptyLineShouldReturnEmptyLine()
        {
            var line = "";
            var sut = new HtmlParser(line);
            var result = sut.Parse(new Dictionary<string, string>());
            result.Should().BeEmpty();
        }
    }
}
