using FluentAssertions;
using Moq;
using Xunit;

namespace Nancy.Bundler.Tests
{
    public class BundleParserFixture
    {
        private readonly Mock<IFileReader> _fileReader;
        private readonly Mock<IAppManager> _appManager;
        private readonly BundleParser _bundleParser;

        public BundleParserFixture()
        {
            _fileReader = new Mock<IFileReader>();
            _appManager = new Mock<IAppManager>();
            _bundleParser = new BundleParser(_fileReader.Object, _appManager.Object);
        }

        [Fact]
        public void GetRelativeFiles()
        {
            var fileLines = new[] {"// ~/foo.js", "// ~/bar.js"};

            _appManager.Setup(x => x.GetRootDirectory()).Returns("");
            _fileReader.Setup(x => x.ReadAllLines(It.IsAny<string>())).Returns(fileLines);

            var result = _bundleParser.GetRelativeFiles("");
            var expectedFiles = new[] {"/foo.js", "/bar.js"};

            result.Should().ContainInOrder(expectedFiles);
        }

        [Fact]
        public void GetPhysicalFiles()
        {
            var fileLines = new[] { "// ~/foo.js", "// ~/bar.js" };

            _appManager.Setup(x => x.GetRootDirectory()).Returns(@"c:\root");
            _fileReader.Setup(x => x.ReadAllLines(It.IsAny<string>())).Returns(fileLines);

            var result = _bundleParser.GetPhysicalFiles("");
            var expectedFiles = new[] { @"c:\root\foo.js", @"c:\root\bar.js" };

            result.Should().ContainInOrder(expectedFiles);
        }
    }
}
