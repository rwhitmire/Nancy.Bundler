using Moq;
using Xunit;

namespace Nancy.Bundler.Tests
{
    public class BundleResolverFixture
    {
        [Fact]
        public void BuildScriptsShouldGetDebugScripts()
        {
            var manager = new Mock<IAppManager>();
            var markupBuilder = new Mock<IMarkupBuilder>();

            manager.Setup(x => x.IsDebugging).Returns(true);

            var resolver = new BundleResolver(manager.Object, markupBuilder.Object);
            resolver.BuildScripts("");

            markupBuilder.Verify(x => x.GetScriptsForDebugging(""), Times.Once);
        }

        [Fact]
        public void BuildScriptsShouldGetProductionScripts()
        {
            var manager = new Mock<IAppManager>();
            var markupBuilder = new Mock<IMarkupBuilder>();

            manager.Setup(x => x.IsDebugging).Returns(false);

            var resolver = new BundleResolver(manager.Object, markupBuilder.Object);
            resolver.BuildScripts("");

            markupBuilder.Verify(x => x.GetScriptsForProduction(""), Times.Once);
        }
    }
}
