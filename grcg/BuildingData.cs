using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace grcg
{
    internal class BuildingData
    {
        private readonly List<Building> _buildings = new List<Building>();

        private BuildingData()
        {
        }

        public static BuildingData Load()
        {
            var data = new BuildingData();
            InitializeBuilding(data);
            AddTranslations(data);
            RandomizeBuildings(data);

            return data;
        }

        private static void RandomizeBuildings(BuildingData data)
        {
            data._buildings.Shuffle();
        }

        private static void AddTranslations(BuildingData data)
        {
            var translationFiles = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"Translations"), "*.lang");
            foreach (var translationFile in translationFiles)
            {
                AddTranslation(data, translationFile);
            }
        }

        private static void AddTranslation(BuildingData data, string translationFile)
        {
            var lines = File.ReadAllLines(translationFile);
            if (lines.Length != data.Count)
            {
                Console.WriteLine($"Translation file '{translationFile}' has an invalid number of entries. Expected: {data.Count}.");
                return;
            };

            var languageName = Path.GetFileNameWithoutExtension(translationFile);

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var building = data._buildings[i];

                building.AddTranslation(languageName, line);
            }
        }

        private int Count => _buildings.Count;

        private static void InitializeBuilding(BuildingData data)
        {
            var buildingData = File.ReadAllLines(@"Buildings.dat");
            foreach (var line in buildingData)
            {
                data.Add(new Building(Enum.Parse<Category>(line)));
            }
        }

        private void Add(Building building)
        {
            _buildings.Add(building);
        }

        public IEnumerable<Building> GetStartingBuildings(Category category)
        {
            return _buildings.Where(p => p.Category == category).Take(4);
        }

        public IEnumerable<Building> GetOfferBuildings(Category category)
        {
            return _buildings.Where(p => p.Category == category).Skip(4).Take(10);
        }
    }
}