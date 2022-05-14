using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using scg.App.Options;

namespace scg.Framework
{
    public class FileRepository : RepositoryBase
    {
        private readonly string _userPath;

        public FileRepository(ScgOptions options, string game) : base($"scg.Games.{game}.")
        {
            var basePath = options?.DataFolder ?? Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _userPath = Path.Combine(basePath, "MadCowDevelopment", "scg", "Games", game);
            Directory.CreateDirectory(_userPath);
        }

        public string ReadAllText(string filename, bool isUserData)
        {
            return isUserData
                ? System.IO.File.ReadAllText(GetPath(filename))
                : ReadEmbeddedResource(filename) ?? string.Empty;
        }

        public string[] ReadAllLines(string filename, bool isUserData)
        {
            return isUserData
                ? System.IO.File.ReadAllLines(GetPath(filename))
                : ReadEmbeddedResource(filename)?.Split(Environment.NewLine) ?? Array.Empty<string>();
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