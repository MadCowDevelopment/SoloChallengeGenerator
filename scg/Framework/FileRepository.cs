using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                ? System.IO.File.ReadAllText(GetPath(filename))
                : ReadEmbeddedResource(filename);
        }

        public string[] ReadAllLines(string filename, bool isUserData)
        {
            return isUserData
                ? System.IO.File.ReadAllLines(GetPath(filename))
                : ReadEmbeddedResource(filename).Split(Environment.NewLine);
        }

        private string GetPath(string filename)
        {
            CopyFromDefaultIfNecessary(filename);
            return Path.Combine(_userPath, filename);
        }

        private void CopyFromDefaultIfNecessary(string filename)
        {
            var userFile = Path.Combine(_userPath, filename);
            if (System.IO.File.Exists(userFile)) return;

            var template = ReadEmbeddedResource(filename);
            System.IO.File.WriteAllText(userFile, template);
        }

        public void AppendLine(string filename, string line)
        {
            var lines = ReadAllLines(filename, true).ToList();
            lines.Add(line);
            System.IO.File.WriteAllLines(GetPath(filename), lines);
        }

        public void WriteAllLines(string filename, IEnumerable<string> contents)
        {
            System.IO.File.WriteAllLines(GetPath(filename), contents);
        }
    }
}