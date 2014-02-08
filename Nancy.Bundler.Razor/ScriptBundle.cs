using Nancy.ViewEngines.Razor;

namespace Nancy.Bundler.Razor
{
    public static class ScriptBundle
    {
        public static IHtmlString Render(string bundleName)
        {
            var orchestrator = new BundleResolver();
            var scripts = orchestrator.BuildScripts(bundleName);

            return new NonEncodedHtmlString(scripts);
        }
    }
}
