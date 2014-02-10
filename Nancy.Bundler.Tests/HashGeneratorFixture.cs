using FluentAssertions;
using Moq;
using Xunit;

namespace Nancy.Bundler.Tests
{
    public class HashGeneratorFixture
    {
        private readonly Mock<IFileReader> _fileReader;
        private readonly HashGenerator _hashGenerator;

        public HashGeneratorFixture()
        {
            _fileReader = new Mock<IFileReader>();
            _hashGenerator = new HashGenerator(_fileReader.Object);
        }
        
        [Fact]
        public void GetFileHash()
        {
            var bytes = new byte[3];
            _fileReader.Setup(x => x.ReadAllBytes(It.IsAny<string>())).Returns(bytes);

            var result = _hashGenerator.GetFileHash("");
            result.Should().NotBeNull();
        }

        [Fact]
        public void GetFileHashShouldDifferWithBytesizeDifference()
        {

            var fooBytes = new byte[3];
            var barBytes = new byte[15];

            _fileReader.Setup(x => x.ReadAllBytes("foo")).Returns(fooBytes);
            _fileReader.Setup(x => x.ReadAllBytes("bar")).Returns(barBytes);

            var fooResult = _hashGenerator.GetFileHash("foo");
            var barResult = _hashGenerator.GetFileHash("bar");

            fooResult.Should().NotMatch(barResult);
        }
    }
}
