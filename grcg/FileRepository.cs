using System;
using System.Collections.Generic;
using System.IO;

namespace grcg
{
    public class FileRepository
    {
        private readonly string _basePath;

        public FileRepository(string game)
        {
            _basePath = Path.Combine(Environment.CurrentDirectory, "Games", game);
        }

        public string ReadAllText(string filename)
        {
            return File.ReadAllText(Path.Combine(_basePath, filename));
        }

        public string[] ReadAllLines(string filename)
        {
            return File.ReadAllLines(Path.Combine(_basePath, filename));
        }

        public IEnumerable<string> GetFiles(string path, string searchPattern)
        {
            return Directory.GetFiles(Path.Combine(_basePath, path), searchPattern);
        }
    }
}