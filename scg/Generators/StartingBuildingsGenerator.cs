using System.Linq;
using System.Text;

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

            var category = arguments[0];
            var number = int.Parse(arguments[1]);
            var startingBuildings = _buildingData.GetAndSkipTakenBuildings(category, number);
            var buildingsGroupedByTranslations = startingBuildings.SelectMany(p => p.Translations).GroupBy(p => p.Key)
                .ToDictionary(p => p.Key, p => p.Select(x => x.Value).ToList());
            foreach (var languageGroup in buildingsGroupedByTranslations)
            {
                builder.AppendLine($"[microbadge={_flags[languageGroup.Key]}] {string.Join(" - ", languageGroup.Value)}");
            }

            builder.Append("[/size]");

            var placeHolder = Token.Replace("{x}", category.ToUpper());
            return template.Replace(placeHolder, builder.ToString());
        }
    }
}