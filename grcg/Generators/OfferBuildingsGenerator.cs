using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grcg.Generators
{
    internal class OfferBuildingsGenerator : TemplateGenerator
    {
        private readonly BuildingData _buildingData;

        public OfferBuildingsGenerator(BuildingData buildingData)
        {
            _buildingData = buildingData;
        }

        public override string Token { get; } = "<<OFFER_BUILDINGS_{x}>>";

        public override string Apply(string template, string[] arguments)
        {
            var builder = new StringBuilder();
            var category = arguments[0];
            var number = int.Parse(arguments[1]);

            var buildingLines = new List<string>();
            foreach (var offerBuilding in _buildingData.GetAndSkipTakenBuildings(category, number))
            {
                buildingLines.Add($"[o][c][size=11]{offerBuilding.ToPostFormat()}%WHITESPACES%[/size][/c][/o]");
            }

            var maxLength = buildingLines.Max(p => p.Length);
            foreach (var buildingLine in buildingLines)
            {
                var differenceToMax = maxLength - buildingLine.Length;
                var whitespaces = string.Join("", Enumerable.Repeat(" ", differenceToMax));
                builder.Append(buildingLine.Replace("%WHITESPACES%", whitespaces));
            }

            var placeHolder = $"<<OFFER_BUILDINGS_{category.ToUpper()}>>";
            return template.Replace(placeHolder, builder.ToString());
        }
    }
}