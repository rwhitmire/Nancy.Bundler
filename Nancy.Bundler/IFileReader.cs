using System.Collections.Generic;

namespace Nancy.Bundler
{
    public interface IFileReader
    {
        string ReadAllText(string path);
        IEnumerable<string> ReadAllLines(string path);
    }
}