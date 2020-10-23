using System;
using System.IO;

namespace scg.Utils
{
    public static class Tools
    {
        public static void FindLongestBuildingName()
        {
            string longestName = string.Empty;
            var translationFiles = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, @"Translations"), "*.lang");
            foreach (var translationFile in translationFiles)
            {
                foreach (var line in File.ReadAllLines(translationFile))
                {
                    if (line.Length > 20)
                    {
                        Console.WriteLine($"'{line}': '{longestName.Length} characters.");
                    }

                    if (line.Length > longestName.Length) longestName = line;
                }
            }

            Console.WriteLine($"The longest name is '{longestName}' with '{longestName.Length} characters.");
        }

        public static void AddTranslationsToExistingPost()
        {
            var existingPost = File.ReadAllText(@".\ExistingPost.txt");
            var englishBuildings = File.ReadAllLines(@".\Translations\English.lang");
            var frenchBuildings = File.ReadAllLines(@".\Translations\French.lang");

            for (int i = 0; i < englishBuildings.Length; i++)
            {
                var english = englishBuildings[i];
                var french = frenchBuildings[i];

                var searchText = $"{english} - ";
                var replaceText = $"{searchText}{french} - ";

                existingPost = existingPost.Replace(searchText, replaceText);
            }

            File.WriteAllText("UpdatedPost.txt", existingPost);
        }

    }
}