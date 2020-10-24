using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Framework;
using scg.Utils;

namespace scg.Generators
{
    internal class ScoringCardGenerator : TemplateGenerator
    {
        private readonly BuildingData _buildingData;
        private readonly Dictionary<int, int> _targetScores;

        public ScoringCardGenerator(BuildingData buildingData)
        {
            _buildingData = buildingData;
            _targetScores = new Dictionary<int, int>
            {
                {18, 17}, {19, 22}, {20, 18}, {21, 25}, {22, 27}, {23, 24}, {24, 20}, {25, 22},
                {26, 16}, {27, 16}, {28, 20}, {29, 21}, {30, 20}, {31, 24}, {32, 24}, {33, 24}
            };
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

            builder.AppendLine();
            var totalTargetScore = scoringCards.Sum(p => _targetScores[p.Id]);
            builder.AppendLine($"Total of the numbers in the lower right corner: [b]{totalTargetScore}[/b]");
            builder.AppendLine("At the end of your game you have to subtract that from your score to find your rating!");

            return template.Replace(Token, builder.ToString());
        }
    }
}