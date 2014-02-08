namespace Nancy.Bundler
{
    public class BundleResolver
    {
        private readonly IAppManager _appManager;
        private readonly IMarkupBuilder _markupBuilder;

        public BundleResolver()
        {
            _appManager = Container.Resolve<IAppManager>();
            _markupBuilder = Container.Resolve<IMarkupBuilder>();
        }

        public BundleResolver(IAppManager appManager, IMarkupBuilder markupBuilder)
        {
            _appManager = appManager;
            _markupBuilder = markupBuilder;
        }

        public string BuildScripts(string bundleName)
        {
            if (_appManager.IsDebugging)
                return _markupBuilder.GetScriptsForDebugging(bundleName);

            return _markupBuilder.GetScriptsForProduction(bundleName);
        }
    }
}
