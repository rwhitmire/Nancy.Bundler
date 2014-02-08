using FluentAssertions;
using Moq;
using Xunit;

namespace Nancy.Bundler.Tests
{
    public class MarkupBuilderFixture
    {
        [Fact]
        public void GetScriptsForDebugging()
        {
            var fileResolver = new Mock<IBundleParser>();
            var builder = new MarkupBuilder(fileResolver.Object);

            var files = new[] {"foo.js", "bar.js"};

            fileResolver.Setup(x => x.GetRelativeFiles(It.IsAny<string>())).Returns(files);

            var result = builder.GetScriptsForDebugging("");
            result.Should().Be("<script src=\"foo.js\"></script><script src=\"bar.js\"></script>");

        }
    }
}