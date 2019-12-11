using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace grcg
{
    internal class BuildingData
    {
        private readonly FileRepository _repository;
        private readonly List<Building> _buildings = new List<Building>();
        private readonly Dictionary<string, int> _takenBuildings = new Dictionary<string, int>();

        public static FlagsDictionary Flags { get; } = new FlagsDictionary();

        public class FlagsDictionary
        {
            private static readonly Dictionary<string, string> _flags = new Dictionary<string, string>
            {
                {"English", "6887"},
                {"French", "6886"},
                {"German", "6922"},
                {"Polish", "6917" },
                {"Spanish", "6889"}
            };

            public string this[string str] => _flags[str];

            public bool Exists(string key)
            {
                return _flags.ContainsKey(key);
            }
        }

        public BuildingData(FileRepository repository)
        {
            _repository = repository;
            Load();
        }

        private void Load()
        {
            InitializeBuilding();
            AddTranslations();
            RandomizeBuildings();
        }

        private void RandomizeBuildings()
        {
            _buildings.Shuffle();
        }

        private void AddTranslations()
        {
            var translationFiles = _repository.GetFiles("Translations", "*.lang");
            foreach (var translationFile in translationFiles)
            {
                AddTranslation(translationFile);
            }
        }

        private void AddTranslation(string translationFile)
        {
            var lines = File.ReadAllLines(translationFile);
            if (lines.Length != Count)
            {
                Console.WriteLine($"Translation file '{translationFile}' has an invalid number of entries. Expected: {Count}.");
                return;
            }

            var languageName = Path.GetFileNameWithoutExtension(translationFile);

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var building = _buildings[i];

                building.AddTranslation(languageName, line);
            }
        }

        private int Count => _buildings.Count;

        private void InitializeBuilding()
        {
            var buildingData = _repository.ReadAllLines("Buildings.dat");
            foreach (var line in buildingData)
            {

                Add(new Building(line));
            }
        }

        private void Add(Building building)
        {
            _buildings.Add(building);
        }

        public IEnumerable<Building> GetAndSkipTakenBuildings(string category, int number)
        {
            var buildingsToSkip = _takenBuildings.ContainsKey(category) ? _takenBuildings[category] : 0;
            var buildings = _buildings.Where(p => string.Equals(p.Category, category, StringComparison.InvariantCultureIgnoreCase)).Skip(buildingsToSkip).Take(number).ToList();

            if (_takenBuildings.ContainsKey(category)) _takenBuildings[category] += buildings.Count;
            else _takenBuildings[category] = buildings.Count;

            return buildings;
        }

        public IEnumerable<Building> GetAll(string category)
        {
            return _buildings.Where(p => string.Equals(p.Category, category, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
    }
}