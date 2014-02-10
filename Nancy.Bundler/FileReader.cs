using System.Collections.Generic;
using System.IO;

namespace Nancy.Bundler
{
    public class FileReader : IFileReader
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public IEnumerable<string> ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }

        public byte[] ReadAllBytes(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}