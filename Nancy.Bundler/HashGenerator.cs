using System;
using System.Security.Cryptography;

namespace Nancy.Bundler
{
    public interface IHashGenerator
    {
        string GetFileHash(string filename);
    }

    public class HashGenerator : IHashGenerator
    {
        private readonly IFileReader _fileReader;

        public HashGenerator(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public string GetFileHash(string filename)
        {
            var fileBytes = _fileReader.ReadAllBytes(filename);

            var hash = MD5.Create().ComputeHash(fileBytes);
            return BitConverter.ToString(hash).Replace("-", ""); 
        }
    }
}
