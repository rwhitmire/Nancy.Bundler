using System;
using System.Collections.Generic;

namespace Nancy.Bundler
{
    public class MarkupBuilder : IMarkupBuilder
    {
        private readonly IBundleParser _bundleParser;

        public MarkupBuilder()
        {
            _bundleParser = Container.Resolve<IBundleParser>();
        }

        public MarkupBuilder(IBundleParser bundleParser)
        {
            _bundleParser = bundleParser;
        }

        public string GetScriptsForDebugging(string bundleName)
        {
            var files = _bundleParser.GetRelativeFiles(bundleName);

            // do something with compiler here when not js or css

            var scripts = GetScriptMarkup(files);

            return scripts;
        }

        public string GetScriptsForProduction(string bundleName)
        {
            // get list of physical file names

            // load the files

            // minify and bundle the files

            // add a hash to the filename

            // do something to cache the file

            throw new NotImplementedException();
        }

        private string GetScriptMarkup(IEnumerable<string> files)
        {
            var markup = string.Empty;

            foreach (var file in files)
            {
                var tag = string.Format("<script src=\"{0}\"></script>", file);
                markup += tag;
            }

            return markup;
        }
    }
}