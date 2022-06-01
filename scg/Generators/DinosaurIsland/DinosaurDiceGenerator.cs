using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using scg.Framework;
using scg.Utils;

namespace scg.Generators.DinosaurIsland;

public class DinosaurDiceGenerator : TemplateGenerator
{
    private readonly BuildingData _buildingData;
    private readonly FlagsDictionary _flags;
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

    public DinosaurDiceGenerator(BuildingData buildingData, FlagsDictionary flags)
    {
        _buildingData = buildingData;
        _flags = flags;
    }

    public override string Token { get; } = "<<DINOSAUR_DICE>>";

    public override string Apply(string template, string[] arguments)
    {
        var isActionPhase = arguments.Length > 0 && arguments[0] == "ACTION";
        var builder = new StringBuilder();
        var diceIds = _diceIds.ToList();
        diceIds.Shuffle();

        if (isActionPhase)
        {
            builder.AppendLine("[o][b]AI dice:[/b]");
            var aiInfo = ParseAI(_buildingData.GetAndSkipTakenBuildings("AI", 1).Single());
            builder.Append("[floatleft][floatleft]");
            foreach (var language in aiInfo.Languages)
            {
                builder.AppendLine($"[microbadge={_flags[language.Key]}] {language.ActionSpot1}");
            }

            builder.Append($"[/floatleft][floatleft][ImageID={GetDieImageId(diceIds, 0)} square inline][/floatleft][/floatleft] [floatleft][floatleft]");
            foreach (var language in aiInfo.Languages)
            {
                builder.AppendLine($"[microbadge={_flags[language.Key]}] {language.ActionSpot2}");
            }

            builder.AppendLine($"[/floatleft][floatleft][ImageID={GetDieImageId(diceIds, 1)} square inline][/floatleft][/floatleft][clear][b]Select your dice:[/b]");
            builder.AppendLine($"[floatleft][ImageID={GetDieImageId(diceIds, 2)} square inline][c]  [/c][ImageID={GetDieImageId(diceIds, 3)} square inline][c]  [/c][ImageID={GetDieImageId(diceIds, 4)} square inline][c]  [/c][ImageID={GetDieImageId(diceIds, 5)} square inline][/floatleft][clear][/o]");
        }
        else
        {
            for (var i = 0; i < 6; i++)
            {
                builder.Append($"[floatleft][o][ImageID={GetDieImageId(diceIds, i)} square inline][/o][/floatleft] ");
            }
        }

        return template.ReplaceFirst(Token, builder.ToString());
    }

    private int GetDieImageId(List<int> diceIds, int i)
    {
        return _dieFaces[diceIds[i] * 6 + RNG.Between(0, 5)];
    }

    private AIInfo ParseAI(Building building)
    {
        var result = new AIInfo();
        foreach (var translation in building.Translations)
        {
            var actionSpots = translation.Value.Split("-").Select(p => p.Trim()).ToList();
            result.Languages.Add(new SingleLanguageAIInfo
                { Key = translation.Key, ActionSpot1 = actionSpots[0], ActionSpot2 = actionSpots[1] });
        }
        return result;
    }

    private class AIInfo
    {
        public List<SingleLanguageAIInfo> Languages { get; } = new();
    }

    private class SingleLanguageAIInfo
    {
        public string Key { get; set; }
        public string ActionSpot1 { get; set; }
        public string ActionSpot2 { get; set; }
    }
}
