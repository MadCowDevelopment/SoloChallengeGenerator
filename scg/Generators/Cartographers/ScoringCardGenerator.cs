using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Framework;
using scg.Utils;

namespace scg.Generators.Cartographers;

internal class ScoringCardGenerator : TemplateGenerator
{
    private readonly BuildingData _buildingData;
    private Dictionary<int, int> _targetScores;
    private Dictionary<int, int> _cardNumbers;

    public ScoringCardGenerator(BuildingData buildingData)
    {
        _buildingData = buildingData;

    }

    public override string Token { get; } = "<<SCORING_CARDS>>";

    public override string Apply(string template, string[] arguments)
    {
        var set = arguments[0];

        InitializeTargetScores(set);
        InitializeCardNumbers(set);

        var scoring1 = _buildingData.GetAndSkipTakenBuildings("Scoring1", 1).Single();
        var scoring2 = _buildingData.GetAndSkipTakenBuildings("Scoring2", 1).Single();
        var scoring3 = _buildingData.GetAndSkipTakenBuildings("Scoring3", 1).Single();
        var scoring4 = _buildingData.GetAndSkipTakenBuildings("Scoring4", 1).Single();

        var scoringCards = new List<Building> { scoring1, scoring2, scoring3, scoring4 };
        scoringCards.Shuffle();

        var builder = new StringBuilder();
        builder.Append("[size=11]");
        builder.AppendLine($"A) #{_cardNumbers[scoringCards[0].Id]} [{_targetScores[scoringCards[0].Id]} pts] {scoringCards[0].ToPostFormat()}");
        builder.AppendLine($"B) #{_cardNumbers[scoringCards[1].Id]} [{_targetScores[scoringCards[1].Id]} pts] {scoringCards[1].ToPostFormat()}");
        builder.AppendLine($"C) #{_cardNumbers[scoringCards[2].Id]} [{_targetScores[scoringCards[2].Id]} pts] {scoringCards[2].ToPostFormat()}");
        builder.AppendLine($"D) #{_cardNumbers[scoringCards[3].Id]} [{_targetScores[scoringCards[3].Id]} pts] {scoringCards[3].ToPostFormat()}");
        builder.Append("[/size]");

        builder.AppendLine();
        var totalTargetScore = scoringCards.Sum(p => _targetScores[p.Id]);
        builder.AppendLine($"Total of the numbers in the lower right corner: [b]{totalTargetScore}[/b]");
        builder.AppendLine("At the end of your game you have to subtract that from your score to find your rating!");

        return template.ReplaceFirst(Token, builder.ToString());
    }

    private void InitializeTargetScores(string set)
    {
        if (set == SetIdentifiers.Base)
        {
            _targetScores = new Dictionary<int, int>
            {
                {18, 17}, {19, 22}, {20, 18}, {21, 25}, {22, 27}, {23, 24}, {24, 20}, {25, 22},
                {26, 16}, {27, 16}, {28, 20}, {29, 21}, {30, 20}, {31, 24}, {32, 24}, {33, 24}
            };
        } else if (set == SetIdentifiers.Heroes)
        {
            _targetScores = new Dictionary<int, int>
            {
                {20, 16}, {21, 18}, {22, 22}, {23, 24}, {24, 12}, {25, 14}, {26, 15}, {27, 18},
                {28, 14}, {29, 12}, {30, 12}, {31, 16}, {32, 28}, {33, 30}, {34, 28}, {35, 30},
            };
        }
    }

    private void InitializeCardNumbers(string set)
    {
        if (set == SetIdentifiers.Base)
        {
            _cardNumbers = new Dictionary<int, int>
            {
                {18, 28}, {19, 27}, {20, 29}, {21, 26}, {22, 33}, {23, 30}, {24, 32}, {25, 31},
                {26, 34}, {27, 35}, {28, 37}, {29, 36}, {30, 41}, {31, 40}, {32, 38}, {33, 39}
            };
        } else if (set == SetIdentifiers.Heroes)
        {
            _cardNumbers = new Dictionary<int, int>
            {
                {20, 28}, {21, 29}, {22, 30}, {23, 31}, {24, 32}, {25, 33}, {26, 34}, {27, 35},
                {28, 36}, {29, 37}, {30, 38}, {31, 39}, {32, 40}, {33, 41}, {34, 42}, {35, 43}
            };
        }
    }
}