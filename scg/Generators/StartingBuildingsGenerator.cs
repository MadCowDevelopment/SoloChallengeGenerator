using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Framework;
using scg.Utils;

namespace scg.Generators
{
    internal class StartingBuildingsGenerator : TemplateGenerator
    {
        private readonly BuildingData _buildingData;
        private readonly FlagsDictionary _flags;

        public StartingBuildingsGenerator(BuildingData buildingData, FlagsDictionary flags)
        {
            _buildingData = buildingData;
            _flags = flags;
        }

        public override string Token { get; } = "<<STARTING_BUILDINGS_{x}>>";
        public override string Apply(string template, string[] arguments)
        {
            var builder = new StringBuilder();
            builder.Append("[size=11]");

            var (category, number, options) = ParseArguments(arguments);

            var startingBuildings = GetStartingBuildings(options, category, number);
            var buildingsGroupedByTranslations = startingBuildings.SelectMany(p => p.Translations).GroupBy(p => p.Key)
                .ToDictionary(p => p.Key, p => p.Select(x => x.Value).ToList());
            foreach (var languageGroup in buildingsGroupedByTranslations)
            {
                var flag = buildingsGroupedByTranslations.Count == 1 ? "" : $"[microbadge={_flags[languageGroup.Key]}] ";
                builder.AppendLine($"{flag}{string.Join(" - ", languageGroup.Value)}");
            }

            builder.Append("[/size]");

            var placeHolder = Token.Replace("{x}", category.ToUpper());
            return template.ReplaceFirst(placeHolder, builder.ToString());
        }

        private (string Category, int Number, StartingBuildingsGeneratorOptions Options) ParseArguments(string[] arguments)
        {
            var category = arguments[0];
            var number = int.Parse(arguments[1]);

            StartingBuildingsGeneratorOptions options = 0;
            if (arguments.Length > 2)
            {
                options = Enum.Parse<StartingBuildingsGeneratorOptions>(string.Join(",", arguments[2].Split("|")));
            }

            return (category, number, options);
        }

        private IEnumerable<Building> GetStartingBuildings(StartingBuildingsGeneratorOptions options, string category, int number)
        {
            return (options & StartingBuildingsGeneratorOptions.Determined) ==
                   StartingBuildingsGeneratorOptions.Determined
                ? _buildingData.GetBuildingsDeterminedByMonth(category, number)
                : _buildingData.GetAndSkipTakenBuildings(category, number);
        }

        [Flags]
        private enum StartingBuildingsGeneratorOptions
        {
            Determined = 1,
        }
    }
}