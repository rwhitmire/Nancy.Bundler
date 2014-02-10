using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace Nancy.Bundler.Tests
{
    public class FileResolverFixture
    {
        [Fact]
        public void GetRelativeFilesShouldParseBundleFile()
        {
            var fileReader = new Mock<IFileReader>();
            var appManager = new Mock<IAppManager>();

            var parser = new BundleParser(fileReader.Object, appManager.Object);

            var lines = new List<string>
            {
                "// ~/foo.js",
                "// ~/bar.js"
            };

            appManager.Setup(x => x.GetRootDirectory()).Returns(string.Empty);
            fileReader.Setup(x => x.ReadAllLines(It.IsAny<string>())).Returns(lines);
            var result = parser.GetRelativeFiles("");

            result.Should().ContainInOrder(new[] {"/foo.js", "/bar.js"});
        }
    }
}