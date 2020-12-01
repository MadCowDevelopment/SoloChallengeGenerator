﻿using System;
using System.Collections.Generic;
using System.Linq;
using scg.Utils;

namespace scg.Framework
{
    public class BuildingData
    {
        private readonly FileRepository _repository;
        private readonly List<Building> _buildings = new List<Building>();
        private readonly List<Building> _takenBuildings = new List<Building>();
        private readonly FlagsDictionary _flags;

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
            var buildingData = _repository.ReadAllLines(File.Buildings, false);
            foreach (var line in buildingData)
            {
                var splits = line.Split(",");
                var category = splits[0].Trim();
                var subcategory = splits.Length > 1 ? splits[1].Trim() : string.Empty;
                Add(new Building(category, subcategory,  _flags));
            }
        }

        private void Add(Building building)
        {
            _buildings.Add(building);
        }

        public IEnumerable<Building> GetAndSkipTakenBuildings(string category, int number)
        {
            var buildings = _buildings.Except(_takenBuildings)
                .Where(p => string.Equals(p.Category, category, StringComparison.InvariantCultureIgnoreCase))
                .Take(number).ToList();
            _takenBuildings.AddRange(buildings);
            return buildings;
        }

        public IEnumerable<Building> GetAndSkipTakenBuildings(string category, IEnumerable<string> subcategories, int number)
        {
            var buildings = _buildings.Except(_takenBuildings)
                .Where(p => string.Equals(p.Category, category, StringComparison.InvariantCultureIgnoreCase) 
                            && subcategories.Any(s => string.Equals(s, p.Subcategory, StringComparison.InvariantCultureIgnoreCase)))
                .Take(number).ToList();
            _takenBuildings.AddRange(buildings);
            return buildings;
        }

        public void ResetTakenBuildings()
        {
            _takenBuildings.Clear();
        }

        public IEnumerable<Building> GetAll(string category)
        {
            return _buildings.Where(p => string.Equals(p.Category, category, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }
    }
}