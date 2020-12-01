using System.Linq;
using System.Text;
using scg.Framework;
using scg.Utils;

namespace scg.Generators
{
    internal class StartingBuildingsWithSubCategoriesGenerator : TemplateGenerator
    {
        private readonly BuildingData _buildingData;
        private readonly FlagsDictionary _flags;

        public StartingBuildingsWithSubCategoriesGenerator(BuildingData buildingData, FlagsDictionary flags)
        {
            _buildingData = buildingData;
            _flags = flags;
        }

        public override string Token { get; } = "<<STARTING_BUILDINGS_{x}_{y}>>";
        public override string Apply(string template, string[] arguments)
        {
            var builder = new StringBuilder();
            builder.Append("[size=11]");

            var category = arguments[0];
            var number = int.Parse(arguments[1]);
            var subcategories = arguments[2].Split("|");
            var startingBuildings = _buildingData.GetAndSkipTakenBuildings(category, subcategories, number);
            var buildingsGroupedByTranslations = startingBuildings.SelectMany(p => p.Translations).GroupBy(p => p.Key)
                .ToDictionary(p => p.Key, p => p.Select(x => x.Value).ToList());

            if (buildingsGroupedByTranslations.Count == 1)
            {
                var languageGroup = buildingsGroupedByTranslations.First();
                builder.Append($"[microbadge={_flags[languageGroup.Key]}] {string.Join(" - ", languageGroup.Value)}");
            }
            else
            {
                foreach (var languageGroup in buildingsGroupedByTranslations)
                {
                    builder.AppendLine($"[microbadge={_flags[languageGroup.Key]}] {string.Join(" - ", languageGroup.Value)}");
                }
            }

            builder.Append("[/size]");

            var placeHolder = Token.Replace("{x}", category.ToUpper());
            placeHolder = placeHolder.Replace("{y}", arguments[2]);
            return template.ReplaceFirst(placeHolder, builder.ToString());
        }
    }
}