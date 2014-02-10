using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Nancy.Bundler
{
    public class BundleParser : IBundleParser
    {
        private readonly IFileReader _fileReader;
        private readonly IAppManager _appManager;

        public BundleParser()
        {
            _fileReader = Container.Resolve<IFileReader>();
            _appManager = Container.Resolve<IAppManager>();
        }

        public BundleParser(IFileReader fileReader, IAppManager appManager)
        {
            _fileReader = fileReader;
            _appManager = appManager;
        }

        public IEnumerable<string> GetRelativeFiles(string bundleName)
        {
            var root = _appManager.GetRootDirectory();
            var physicalPath = Path.Combine(root, bundleName);
            var lines = _fileReader.ReadAllLines(physicalPath);
            var files = lines.Select(RemoveCommentAndPeriod);

            return files;
        }

        private static string RemoveCommentAndPeriod(string line)
        {
            return line.Replace("//", "").Replace("~/", "/").Trim();
        }
    }
}