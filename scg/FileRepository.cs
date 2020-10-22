using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace scg
{
    public class GlobalRepository : RepositoryBase
    {
        public GlobalRepository() : base("scg.")
        {
        }

        public string[] ReadAllLines(string filename)
        {
            return ReadEmbeddedResource(filename).Split(Environment.NewLine);
        }
    }

    public abstract class RepositoryBase
    {
        private readonly string _resourcePath;

        protected RepositoryBase(string resourcePath)
        {
            _resourcePath = resourcePath;
        }

        protected string ReadEmbeddedResource(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames().ToList();

            using (var stream = assembly.GetManifestResourceStream($"{_resourcePath}{filename}"))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public IEnumerable<string> GetFiles(string path, string endsWith)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceNames()
                .Where(str => str.StartsWith($"{_resourcePath}{path}") && str.EndsWith(endsWith))
                .Select(p => p.Replace(_resourcePath, ""));
        }
    }

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