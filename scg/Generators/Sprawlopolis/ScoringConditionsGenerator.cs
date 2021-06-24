using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Framework;
using scg.Utils;

namespace scg.Generators.Sprawlopolis
{
    public class ScoringConditionsGenerator : TemplateGenerator
    {
        private readonly BuildingData _buildingData;
        private readonly FlagsDictionary _flags;

        private List<Building> _chosenScoringCards;

        private readonly Dictionary<int, string> _cardDetails;


        public ScoringConditionsGenerator(BuildingData buildingData, FlagsDictionary flags, GameOptions options)
        {
            _buildingData = buildingData;
            _flags = flags;
            _cardDetails = options.Id == "Agropolis" ? new AgropolisCardDetails() : new SprawlopolisCardDetails();
        }

        public override string Token { get; } = "<<SCORING_CONDITIONS_{x}>>";

        public override string Apply(string template, string[] arguments)
        {
            var builder = new StringBuilder();
            var category = arguments[0];
            switch (category)
            {
                case "DETAILED":
                {
                    _chosenScoringCards ??= _buildingData.GetAndSkipTakenBuildings("CARD", 3).ToList();
                    foreach (var card in _chosenScoringCards)
                    {
                        builder.AppendLine($"[BGCOLOR=#FFFFCC]{X(card)}[/BGCOLOR]");
                        builder.AppendLine(_cardDetails[card.Id]);
                        builder.AppendLine();
                    }

                    break;
                }
                case "SHORT":
                    foreach (var card in _chosenScoringCards)
                    {
                        builder.AppendLine(X(card));
                    }

                    break;
                case "TARGET":
                    builder.Append(_chosenScoringCards.Sum(p => p.Id));
                    break;
                case "CARD":
                    foreach (var card in _buildingData.GetAndSkipTakenBuildings("CARD", int.Parse(arguments[1])))
                    {
                        builder.AppendLine(X(card));
                    }

                    break;
            }

            var placeHolder = Token.Replace("{x}", category.ToUpper());
            return template.ReplaceFirst(placeHolder, builder.ToString());
        }

        private string X(Building building)
        {
            var buildingsGroupedByTranslations = building.Translations.GroupBy(p => p.Key)
                .ToDictionary(p => p.Key, p => p.Select(x => x.Value).ToList());

            var complete = buildingsGroupedByTranslations
                    .Select(languageGroup => $"[microbadge={_flags[languageGroup.Key]}] {languageGroup.Value.First()}");

            return $"[b][c]{building.Id:00}[/c][/b] " + string.Join(" - ", complete);
        }
    }
}
