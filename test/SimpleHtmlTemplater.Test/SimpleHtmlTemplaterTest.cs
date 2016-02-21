using System.Collections.Generic;
using Moq;
using Ploeh.AutoFixture;
using SimpleHtmlTemplater.Test.TestModels;
using Xunit;
using FluentAssertions;

namespace SimpleHtmlTemplater.Test
{
    public class TemplaterTest
    {
        [Fact]
        public void GeneratesHtmlWithoutModel()
        {
            var mockModelConverter = new Mock<IModelConverter>();
            var sut = new Templater(mockModelConverter.Object);

            var result = sut.AddTemplate("<div>This is a test</div>")
                            .AddTemplate("<div>new row</div>")
                            .Build();

            result.Should().Be("<div>This is a test</div><div>new row</div>");
        }

        [Fact]
        public void GeneratesHtmlWithModel()
        {
            var fixture = new Fixture();
            var model = fixture.Create<TwoStringAndIntModel>();

            var mockModelConverter = new Mock<IModelConverter>();
            mockModelConverter.Setup(m => m.Convert(model)).Returns(() =>
            {
                return new Dictionary<string, string>
                {
                    {"Firstname", model.Firstname},
                    {"Lastname", model.Lastname},
                    {"Age", model.Age.ToString()}
                };
            });

            var sut = new Templater(mockModelConverter.Object);

            var result = sut.AddTemplate("<div>This {Firstname} is a test</div>", model)
                            .AddTemplate("<div>{Lastname} and {Age} has new row</div>", model)
                            .Build();

            result.Should().Be($"<div>This {model.Firstname} is a test</div><div>{model.Lastname} and {model.Age} has new row</div>");
        }
    }
}
