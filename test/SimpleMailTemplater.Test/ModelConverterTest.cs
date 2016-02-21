using FluentAssertions;
using Moq;
using Ploeh.AutoFixture;
using SimpleHtmlTemplater.Converters;
using SimpleHtmlTemplater.Test.TestModels;
using Xunit;

namespace SimpleHtmlTemplater.Test
{
    public class ModelConverterTest
    {
        [Fact]
        public void VerifyDictonaryAreBuildingAndCallingCorrectConverters()
        {
            var mockContainer = new Mock<IConverterContainer>();
            var model = new TwoStringAndIntModel { Firstname = "string", Lastname = "string", Age = 1};

            mockContainer.Setup(m => m.GetConverter(typeof(string)))
                .Returns(new DefaultConverter());

            mockContainer.Setup(m => m.GetConverter(typeof(int)))
                .Returns(new DefaultConverter());

            var sut = new ModelConverter(mockContainer.Object);
            var result = sut.Convert(model);
            
            mockContainer.Verify(m => m.GetConverter(typeof(string)), Times.Exactly(2));
            mockContainer.Verify(m => m.GetConverter(typeof(int)), Times.Exactly(1));

            result.Should().ContainKey("Age").WhichValue.Should().Be("1");
            result.Should().ContainKey("Firstname").WhichValue.Should().Be("string");
            result.Should().ContainKey("Lastname").WhichValue.Should().Be("string");
        }
    }
}
