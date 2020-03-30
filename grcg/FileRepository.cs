using System;
using System.Collections.Generic;
using System.IO;

namespace grcg
{
    public class FileRepository
    {
        private readonly string _basePath;

        private readonly string _userPath;

        public FileRepository(string game)
        {
            _userPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MadCowDevelopment", "grcg", "Games", game);
            Directory.CreateDirectory(_userPath);
            _basePath = Path.Combine(Environment.CurrentDirectory, "Games", game);
        }

        public string ReadAllText(string filename, bool isUserData)
        {
            return File.ReadAllText(Path.Combine(GetPath(filename, isUserData), filename));
        }

        public string[] ReadAllLines(string filename, bool isUserData)
        {
            return File.ReadAllLines(Path.Combine(GetPath(filename, isUserData), filename));
        }

        public IEnumerable<string> GetFiles(string path, string searchPattern)
        {
            return Directory.GetFiles(Path.Combine(_basePath, path), searchPattern);
        }

        private string GetPath(string filename, bool isUserData)
        {
            string path;
            if (isUserData)
            {
                CopyFromDefaultIfNecessary(filename);
                path = _userPath;
            }
            else
            {
                path = _basePath;
            }

            return path;
        }

        private void CopyFromDefaultIfNecessary(string filename)
        {
            var userFile = Path.Combine(_userPath, filename);
            if (File.Exists(userFile)) return;
            var templateFile = Path.Combine(_basePath, filename);
            File.Copy(templateFile, userFile);
        }
    }
}