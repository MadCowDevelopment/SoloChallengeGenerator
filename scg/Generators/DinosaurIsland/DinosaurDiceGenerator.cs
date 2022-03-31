using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Framework;
using scg.Utils;

namespace scg.Generators.DinosaurIsland;

public class DinosaurDiceGenerator : TemplateGenerator
{
    private readonly BuildingData _buildingData;
    private List<int> _diceIds = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private List<int> _dieFaces = new()
    {
        6778142, 6778144, 6778145, 6778146, 6778181, 6778148,
        6778175, 6778176, 6778178, 6778180, 6778181, 6778183,
        6778155, 6778156, 6778157, 6778158, 6778159, 6778160,
        6778168, 6778169, 6778171, 6778147, 6778173, 6778174,
        6778136, 6778137, 6778138, 6778139, 6778153, 6778141,
        6778149, 6778150, 6778151, 6778203, 6778153, 6778154,
        6778129, 6778130, 6778131, 6778140, 6778133, 6778135,
        6778161, 6778162, 6778164, 6778165, 6778166, 6778167,
        6778184, 6778186, 6778187, 6778189, 6778190, 6778192,
        6778193, 6778194, 6778195, 6778198, 6778166, 6778205,
    };

    public DinosaurDiceGenerator(BuildingData buildingData)
    {
        _buildingData = buildingData;
    }

    public override string Token { get; } = "<<DINOSAUR_DICE>>";

    public override string Apply(string template, string[] arguments)
    {
        var isActionPhase = arguments.Length > 0 && arguments[0] == "ACTION";
        var builder = new StringBuilder();
        builder.Append("[o][c]");
        var diceIds = _diceIds.ToList();
        diceIds.Shuffle();

        for (var i = 0; i < (isActionPhase ? 6 : 4); i++)
        {
            var currentDieIndex = diceIds[i] * 6 + RNG.Between(0, 5);
            var imageId = _dieFaces[currentDieIndex];
            builder.Append($"[ImageID={imageId} square inline]  ");
        }

        if (isActionPhase)
        {
            builder.AppendLine();
            builder.AppendLine();

            foreach (var offerBuilding in _buildingData.GetAndSkipTakenBuildings("AI", 1))
            {
                builder.Append($"[size=11]{offerBuilding.ToPostFormat()}[/size]");
            }
        }

        builder.Append("[/c][/o]");

        return template.ReplaceFirst(Token, builder.ToString());
    }
}
