using System.Collections.Generic;

namespace Nancy.Bundler
{
    public interface IBundleParser
    {
        IEnumerable<string> GetRelativeFiles(string bundleName);
        IEnumerable<string> GetPhysicalFiles(string bundleName);
    }
}