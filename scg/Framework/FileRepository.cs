using System;
using System.IO;

namespace scg.Framework
{
    public class FileRepository : RepositoryBase
    {
        private readonly string _userPath;

        public FileRepository(string game) : base($"scg.Games.{game}.")
        {
            _userPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "MadCowDevelopment", "scg", "Games", game);
            Directory.CreateDirectory(_userPath);
        }

        public string ReadAllText(string filename, bool isUserData)
        {
            return isUserData
                ? File.ReadAllText(Path.Combine(GetPath(filename), filename))
                : ReadEmbeddedResource(filename);
        }

        public string[] ReadAllLines(string filename, bool isUserData)
        {
            return isUserData
                ? File.ReadAllLines(Path.Combine(GetPath(filename), filename))
                : ReadEmbeddedResource(filename).Split(Environment.NewLine);
        }

        private string GetPath(string filename)
        {
            CopyFromDefaultIfNecessary(filename);
            return _userPath;
        }

        private void CopyFromDefaultIfNecessary(string filename)
        {
            var userFile = Path.Combine(_userPath, filename);
            if (File.Exists(userFile)) return;

            var template = ReadEmbeddedResource(filename);
            File.WriteAllText(userFile, template);
        }
    }
}