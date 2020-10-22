using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scg.Generators
{
    internal class ScoringCardGenerator : TemplateGenerator
    {
        private readonly BuildingData _buildingData;

        public ScoringCardGenerator(BuildingData buildingData)
        {
            _buildingData = buildingData;
        }

        public override string Token { get; } = "<<SCORING_CARDS>>";

        public override string Apply(string template, string[] arguments)
        {
            var scoring1 = _buildingData.GetAndSkipTakenBuildings("Scoring1", 1).Single();
            var scoring2 = _buildingData.GetAndSkipTakenBuildings("Scoring2", 1).Single();
            var scoring3 = _buildingData.GetAndSkipTakenBuildings("Scoring3", 1).Single();
            var scoring4 = _buildingData.GetAndSkipTakenBuildings("Scoring4", 1).Single();

            var scoringCards = new List<Building> { scoring1, scoring2, scoring3, scoring4 };
            scoringCards.Shuffle();

            var builder = new StringBuilder();
            builder.Append("[size=11]");

            builder.AppendLine($"A) {scoringCards[0].ToPostFormat()}");
            builder.AppendLine($"B) {scoringCards[1].ToPostFormat()}");
            builder.AppendLine($"C) {scoringCards[2].ToPostFormat()}");
            builder.AppendLine($"D) {scoringCards[3].ToPostFormat()}");

            builder.Append("[/size]");

            return template.Replace(Token, builder.ToString());
        }
    }
}