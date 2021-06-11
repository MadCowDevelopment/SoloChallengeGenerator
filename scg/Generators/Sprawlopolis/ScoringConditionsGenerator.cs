// © Baker Hughes Company. All rights reserved.
// This document contains confidential and proprietary information owned by Baker Hughes Company.
// Do not use, copy or distribute without permission.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Framework;
using scg.Utils;
using Svg.FilterEffects;

namespace scg.Generators.Sprawlopolis
{
    public class ScoringConditionsGenerator : TemplateGenerator
    {
        private readonly BuildingData _buildingData;
        private readonly FlagsDictionary _flags;
        private static readonly string N = Environment.NewLine;

        private List<Building> _chosenScoringCards;

        private Dictionary<int, string> _cardDetails = new Dictionary<int, string>
        {
            { 1, $"1 pt / Road that does not end at the edge of the city.{N}-1 pt / Road that ends at the edge of the city." },
            { 2, $"1 pt / Each row & column with exactly 3 Park blocks in it.{N}-1 pt / Each row & column with exactly 0 Park blocks in it." },
            { 3, $"1 pt / Park block in your city.{N}-3 pts / Industrial block in your city." },
            { 4, $"Score points per group of 4 \"corner to corner\" blocks of the same type. You may score multiple groups of the same type and a block may apply to more than one group." +
                 $"{N}[c]# of groups:  0  1  2  3  4  5+" +
                 $"{N}     Points: -8 -5 -2  1  4  7[/c]" },
            { 5, $"2 pts / Industrial block adjacent to only Commercial and Industrial blocks." },
            { 6, $"Subtract the number of blocks in your largest Industrial group from the number of blocks in your largest Residential group. Score that many points." },
            { 7, $"1pt / Park block located on the interior of the city.{N}-2 pts / Park block on the edge of the city." },
            { 8, $"1 pt / Park block adjacent to your largest group of Residential blocks.{N}-2 pts / Industrial block adjacent to your largest group of Residential blocks." },
            { 9, $"1 pt / Industrial block that shares a corner with at least 1 other Industrial block." },
            { 10, $"1 pt / Commercial block in any 1 Row or Column of your choice. You may only score for 1 Row or Column." },
            { 11, $"2 pts / Commercial block directly between two Residential blocks with the same road connecting all three blocks. Blocks may be a straight line or in a \"stepped\" pattern." },
            { 12, $"1 pt / every 2 Road sections (rounded down) that are part of your longest road." },
            { 13, $"3 pts / Road that begins at one Park and ends at a different Park." },
            { 14, $"1 pt / Road section in a completed loop. You may score multiple loops in your city." },
            { 15, $"2 pts / Residential block adjacent to 2 or more Industrial blocks." },
            { 16, $"2 pts / Road that passes through both a Residential block and a Commercial block." },
            { 17, $"1 pt / Commercial block on the edge of the city.{N}Additional 1 pt / Commercial block on a corner edge." },
            { 18, $"Add the number of blocks in your longest Row to the number of blocks in your longest Column (skipping any gaps). Score that many points." },
        };

        public ScoringConditionsGenerator(BuildingData buildingData, FlagsDictionary flags)
        {
            _buildingData = buildingData;
            _flags = flags;
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
                        builder.AppendLine($"[BGCOLOR=#FFFFCC]{card.Translations.First().Value}[/BGCOLOR]");
                        builder.AppendLine(_cardDetails[card.Id]);
                        builder.AppendLine();
                    }

                    break;
                }
                case "SHORT":
                    foreach (var card in _chosenScoringCards)
                    {
                        builder.AppendLine($"{card.Translations.First().Value}:");
                    }
                    break;
                case "TARGET":
                    builder.Append(_chosenScoringCards.Sum(p => p.Id));
                    break;
                case "CARD":
                    foreach (var card in _buildingData.GetAndSkipTakenBuildings("CARD", int.Parse(arguments[1])))
                    {
                        builder.AppendLine(card.Translations.First().Value);
                    }
                    break;
            }

            var placeHolder = Token.Replace("{x}", category.ToUpper());
            return template.ReplaceFirst(placeHolder, builder.ToString());
        }
    }
}
