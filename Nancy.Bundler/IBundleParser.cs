using System.Collections.Generic;

namespace Nancy.Bundler
{
    public interface IBundleParser
    {
        IEnumerable<string> GetRelativeFiles(string bundleName);
    }
}