using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace grcg.Generators
{
    internal class SeasonGenerator : TemplateGenerator
    {
        private readonly BuildingData _buildingData;

        private readonly List<Building> _ambushPool = new List<Building>();
        private readonly Dictionary<int, CardData> _cardData = new Dictionary<int, CardData>();

        public SeasonGenerator(BuildingData buildingData)
        {
            _buildingData = buildingData;

            _cardData.Add(1, new CardData(1, new[] {TerrainType.Farm},
                "   |  X\n" +
                "X  | XXX\n" +
                "XG |  X\n" +
                "   |\n"));
            _cardData.Add(2, new CardData(2, new[] { TerrainType.Forest, TerrainType.Village },
                " \n" +
                "  XX\n" +
                "XXX \n" +
                " \n"));
            _cardData.Add(3, new CardData(2, new[] { TerrainType.Village, TerrainType.Water },
                " \n" +
                "XXXX\n" +
                " \n" +
                " \n"));
            _cardData.Add(4, new CardData(2, new[] { TerrainType.Village, TerrainType.Farm },
                "X\n" +
                "XX\n" +
                "X\n" +
                " \n"));
            _cardData.Add(5, new CardData(1, new[] { TerrainType.Water },
                "X  |   X\n" +
                "XG |  XX\n" +
                "X  | XX\n" +
                "   |\n"));
            _cardData.Add(6, new CardData(2, new[] { TerrainType.Farm, TerrainType.Water },
                "XXX\n" +
                "X\n" +
                "X\n" +
                " \n"));
            _cardData.Add(7, new CardData(2, new[] { TerrainType.Forest, TerrainType.Farm },
                " \n" +
                "XXX\n" +
                "  X\n" +
                " \n"));
            _cardData.Add(8, new CardData(0, new[] { TerrainType.Forest, TerrainType.Village, TerrainType.Farm, TerrainType.Water, TerrainType.Monster },
                " \n" +
                "X\n" +
                " \n" +
                " \n"));
            _cardData.Add(9, new CardData(2, new[] { TerrainType.Forest, TerrainType.Water },
                "X\n" +
                "XXX\n" +
                "X\n" +
                " \n"));
            _cardData.Add(10, new CardData(1, new[] { TerrainType.Forest },
                "    | X\n" +
                "X   | XX\n" +
                " XG |  X\n" +
                "    |\n"));
            _cardData.Add(11, new CardData(1, new[] { TerrainType.Village },
                "    |\n" +
                "X   | XXX\n" +
                "XXG | XX\n" +
                "    |\n"));
            _cardData.Add(14, new CardData(0, new[] { TerrainType.Monster },
                "D XX \n" +
                "  X\n" +
                "  XX\n" +
                " \n"));
            _cardData.Add(15, new CardData(0, new[] { TerrainType.Monster },
                "X \n" +
                " X \n" +
                "  X U\n" +
                " \n"));
            _cardData.Add(16, new CardData(0, new[] { TerrainType.Monster },
                "    D\n" +
                "XOX \n" +
                "XOX \n" +
                " \n"));
            _cardData.Add(17, new CardData(0, new[] { TerrainType.Monster },
                "  X\n" +
                "  XX\n" +
                "U X\n" +
                " \n"));
        }

        public override string Token { get; } = "<<SEASON_{x}>>";

        public override string Apply(string template, string[] arguments)
        {
            var season = arguments[0];
            var timeThreshold = GetTimeThreshold(season);
            var maxPossibleCards = GetMaxPossibleCards(season);
            int usedTime = 0;
            int cardsDrawn = 0;

            var exploreDeck = PrepareExploreDeck();

            var builder = new StringBuilder();
            while (usedTime < timeThreshold)
            {
                var drawnCardsThisTurn = new List<Building>();

                Building currentCard;
                do
                {
                    currentCard = exploreDeck[cardsDrawn++];
                    drawnCardsThisTurn.Add(currentCard);
                    if (_ambushPool.Contains(currentCard)) _ambushPool.Remove(currentCard);
                } while (currentCard.Id == 12 || currentCard.Id == 13);

                var cardData = _cardData[currentCard.Id];
                usedTime += cardData.Time;

                builder.AppendLine($"[o][size=11][b]{season} - {usedTime}/{timeThreshold}[/b]: [microbadge=12865] {string.Join("[microbadge=12865][microbadge=10792][microbadge=12865]", drawnCardsThisTurn.Select(p => p.ToPostFormat()))}");
                AppendCardData(builder, cardData);
            }

            while (cardsDrawn <= maxPossibleCards)
            {
                var cardData = CardData.Placeholder;
                builder.AppendLine($"[o][size=11][b]{season} - {usedTime}/{timeThreshold}[/b]: [microbadge=12865] Season is over");
                AppendCardData(builder, cardData);
                cardsDrawn++;
            }

            var placeHolder = $"<<SEASON_{season.ToUpper()}>>";
            return template.Replace(placeHolder, builder.ToString());
        }

        private int GetTimeThreshold(string season)
        {
            switch (season)
            {
                case "Spring":
                case "Summer":
                    return 8;
                case "Autumn":
                    return 7;
                case "Winter":
                    return 6;
                default: throw new InvalidOperationException($"What kind of season is '{season}'?");
            }
        }

        private int GetMaxPossibleCards(string season)
        {
            switch (season)
            {
                case "Spring": return 8;
                case "Summer": return 9;
                case "Autumn": return 9;
                case "Winter": return 10;
                default: throw new InvalidOperationException($"What kind of season is '{season}'?");
            }
        }

        private List<Building> PrepareExploreDeck()
        {
            var exploreDeck = new List<Building>();
            exploreDeck.AddRange(_buildingData.GetAll("Explore"));
            _ambushPool.AddRange(_buildingData.GetAndSkipTakenBuildings("Ambush", 1));
            exploreDeck.AddRange(_ambushPool);
            exploreDeck.Shuffle();
            return exploreDeck;
        }

        private static void AppendCardData(StringBuilder builder, CardData cardData)
        {
            builder.AppendLine();
            builder.AppendLine(cardData.PrintTerrainTypes());
            builder.AppendLine();
            builder.Append(cardData.PrintShapes());
            builder.Append("[/size][/o]");
        }

        private class CardData
        {
            private readonly IEnumerable<TerrainType> _terrainTypes;
            private readonly string _shapeDescription;

            public CardData(int time, IEnumerable<TerrainType> terrainTypes, string shapeDescription)
            {
                Time = time;
                _terrainTypes = terrainTypes;
                _shapeDescription = shapeDescription;
            }

            public static CardData Placeholder { get; } = new CardData(0, new[] {TerrainType.None}, " \n \n \n \n");

            public int Time { get; }

            public string PrintTerrainTypes()
            {
                return string.Join("[microbadge=12865]|[microbadge=12865]", _terrainTypes.Select(p =>
                {
                    switch (p)
                    {
                        case TerrainType.None:
                            return "[microbadge=12865]";
                        case TerrainType.Farm:
                            return "[microbadge=46466] Farm";
                        case TerrainType.Forest:
                            return "[microbadge=46467] Forest";
                        case TerrainType.Village:
                            return "[microbadge=46464] Village";
                        case TerrainType.Water:
                            return "[microbadge=46465] Water";
                        case TerrainType.Monster:
                            return "[microbadge=46463] Monster";
                        default:
                            throw new InvalidOperationException("Unsupported terrain type.");
                    }
                }));
            }

            public string PrintShapes()
            {
                var shape = _shapeDescription;
                shape = shape.Replace(" ", "[microbadge=12865]");
                shape = shape.Replace("X", "[microbadge=23792]");
                shape = shape.Replace("O", "[microbadge=2301]");
                shape = shape.Replace("G", "[microbadge=47]");
                shape = shape.Replace("U", "[microbadge=10790]");
                shape = shape.Replace("D", "[microbadge=10788]");
                return shape;
            }
        }

        private enum TerrainType
        {
            None,
            Farm,
            Forest,
            Village,
            Water,
            Monster
        }
    }
}