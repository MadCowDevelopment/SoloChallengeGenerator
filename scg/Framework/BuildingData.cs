using System;
using System.Collections.Generic;
using System.Linq;
using scg.Utils;

namespace scg.Framework
{
    internal class BuildingData
    {
        private readonly FileRepository _repository;
        private readonly List<Building> _buildings = new List<Building>();
        private readonly Dictionary<string, int> _takenBuildings = new Dictionary<string, int>();
        private FlagsDictionary _flags;

        public BuildingData(FileRepository repository, FlagsDictionary flags)
        {
            _repository = repository;
            _flags = flags;
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
            var translationFiles = _repository.GetFiles("Translations", ".lang");
            foreach (var translationFile in translationFiles)
            {
                AddTranslation(translationFile);
            }
        }

        private void AddTranslation(string translationFile)
        {
            var lines = _repository.ReadAllLines(translationFile, false);
            if (lines.Length != Count)
            {
                Console.WriteLine($"Translation file '{translationFile}' has an invalid number of entries. Expected: {Count}.");
                return;
            }

            var languageName = translationFile.Replace("Translations.", "").Replace(".lang", "");

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
            var buildingData = _repository.ReadAllLines("Buildings.dat", false);
            foreach (var line in buildingData)
            {

                Add(new Building(line, _flags));
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