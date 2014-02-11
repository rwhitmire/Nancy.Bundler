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
            return ReadBundle(bundleName);
        }

        public IEnumerable<string> GetPhysicalFiles(string bundleName)
        {
            var lines = ReadBundle(bundleName);
            
            var physicalFiles = lines.Select(GetPhysicalFilePath);

            return physicalFiles;
        }

        private string GetPhysicalFilePath(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return "";

            if (fileName[0] == '/') 
                fileName = fileName.Substring(1, fileName.Length-1);

            var root = _appManager.GetRootDirectory();
            
            return Path.Combine(root, fileName);
        }

        private IEnumerable<string> ReadBundle(string bundleName)
        {
            var root = _appManager.GetRootDirectory();
            var physicalPath = Path.Combine(root, bundleName);
            var lines = _fileReader.ReadAllLines(physicalPath).Select(RemoveCommentAndPeriod);
            return lines;
        }

        private static string RemoveCommentAndPeriod(string line)
        {
            return line.Replace("//", "").Replace("~/", "/").Trim();
        }
    }
}