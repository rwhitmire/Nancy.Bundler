﻿using System.Web;

namespace Nancy.Bundler.Helpers
{
    public static class ScriptBundle
    {
        public static IHtmlString Render(string bundleName)
        {
            var orchestrator = new BundleResolver();
            var scripts = orchestrator.BuildScripts(bundleName);

            return new HtmlString(scripts);
        }
    }
}
