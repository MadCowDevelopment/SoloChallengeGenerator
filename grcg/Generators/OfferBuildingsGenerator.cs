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
            foreach (var offerBuilding in _buildingData.GetOfferBuildings(category, number))
            {
                builder.Append($"[o][size=11]{offerBuilding.ToPostFormat()}[/size][/o]");
            }

            var placeHolder = $"<<OFFER_BUILDINGS_{category.ToUpper()}>>";
            return template.Replace(placeHolder, builder.ToString());
        }
    }
}