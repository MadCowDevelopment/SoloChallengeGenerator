using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Framework;
using scg.Utils;

namespace scg.Generators.Cartographers;

internal class SeasonGenerator : TemplateGenerator
{
    private readonly BuildingData _buildingData;

    private static readonly string NL = Environment.NewLine;

    private readonly List<Building> _ambushPool = new();
    private readonly List<Building> _heroesPool = new();
    private readonly List<string> _afterSeasonScoringEffects = new();
    private Dictionary<int, CardData> _cardData = new();

    public SeasonGenerator(BuildingData buildingData)
    {
        _buildingData = buildingData;
    }

    public override string Token { get; } = "<<SEASON_{x}>>";

    public override string Apply(string template, string[] arguments)
    {
        var season = arguments[0];
        var set = arguments[1];

        InitializeCardData(set);

        var timeThreshold = GetTimeThreshold(season, set);
        var maxPossibleCards = GetMaxPossibleCards(season);
        var usedTime = 0;
        var cardsDrawn = 0;
        var previousTurnWasRuinsAndMonster = false;

        var exploreDeck = PrepareExploreDeck(set);

        var builder = new StringBuilder();

        while (usedTime < timeThreshold)
        {
            var drawnCardsThisTurn = new List<Building>();
            var drawRuins = false;

            Building currentCard;
            do
            {
                currentCard = exploreDeck[cardsDrawn++];
                drawnCardsThisTurn.Add(currentCard);
                if (_ambushPool.Contains(currentCard)) _ambushPool.Remove(currentCard);
                else if (_heroesPool.Contains(currentCard)) _heroesPool.Remove(currentCard);
            } while (currentCard.IsRuins(set));

            var cardData = _cardData[currentCard.Id];
            usedTime += cardData.Time;

            if (cardData.HasAfterScoringEffect) _afterSeasonScoringEffects.Add(cardData.AfterScoringEffect);

            if (cardData.IsMonster || cardData.IsHero) maxPossibleCards++;

            if (!cardData.IsMonster && previousTurnWasRuinsAndMonster)
            {
                previousTurnWasRuinsAndMonster = false;
                drawRuins = true;
            }

            if (drawnCardsThisTurn.Any(p => p.IsRuins(set)))
            {
                if (cardData.IsMonster)
                {
                    previousTurnWasRuinsAndMonster = true;
                    drawRuins = false;
                }
                else drawRuins = true;
            }

            builder.AppendLine($"[o][c][size=11][b]{season} - {usedTime}/{timeThreshold}[/b]: [microbadge=12865] {string.Join("[microbadge=12865][microbadge=10792][microbadge=12865]", drawnCardsThisTurn.Select(p => p.ToPostFormat()))}");
            AppendCardData(builder, cardData, drawRuins);
        }

        var extraSpoilers = Math.Min(maxPossibleCards - cardsDrawn, 2);
        while (extraSpoilers > 0)
        {
            var cardData = CardData.Placeholder;
            builder.AppendLine($"[o][c][size=11][b]{season} - {usedTime}/{timeThreshold}[/b]: [microbadge=12865] Season is over");
            AppendCardData(builder, cardData, false);
            extraSpoilers--;
        }

        var seasonNumber = GetSeasonNumber(season);
        if (set == SetIdentifiers.Heroes && seasonNumber < 4 && _afterSeasonScoringEffects.Any())
        {
            builder.AppendLine("[b][size=18]After season scoring:[/size][/b]");
            builder.AppendLine($"[o][c][size=11][microbadge=12865]Perform the following monster action{AddPluralSIf(() => _afterSeasonScoringEffects.Count>1)}:");
            builder.AppendLine("__________________________________________________________________________________________________________________________");
            builder.AppendLine();
            foreach (var afterSeasonScoringEffect in _afterSeasonScoringEffects)
            {
                builder.AppendLine(afterSeasonScoringEffect);
            }

            builder.AppendLine();
            builder.AppendLine("[/size][/c][/o]");
        }

        var placeHolder = $"<<SEASON_{season.ToUpper()}>>";
        return template.ReplaceFirst(placeHolder, builder.ToString());
    }

    private string AddPluralSIf(Func<bool> predicate)
    {
        return predicate() ? "s" : string.Empty;
    }

    private void InitializeCardData(string set)
    {
        if (set == "Base")
        {
            _cardData = BaseCardData.Generate();
        } else if (set == SetIdentifiers.Heroes)
        {
            _cardData = HeroesCardData.Generate();
        }
    }

    private static int GetTimeThreshold(string season, string set)
    {
        return season switch
        {
            "Spring" => 8,
            "Summer" => set == "Base" ? 8 : 7,
            "Autumn" => 7,
            "Winter" => 6,
            _ => throw new InvalidOperationException($"What kind of season is '{season}'?")
        };
    }

    private static int GetMaxPossibleCards(string season)
    {
        return season switch
        {
            "Spring" => 8,
            "Summer" => 9,
            "Autumn" => 9,
            "Winter" => 10,
            _ => throw new InvalidOperationException($"What kind of season is '{season}'?")
        };
    }

    private static int GetSeasonNumber(string season)
    {
        return season switch
        {
            "Spring" => 1,
            "Summer" => 2,
            "Autumn" => 3,
            "Winter" => 4,
            _ => throw new InvalidOperationException($"What kind of season is '{season}'?")
        };
    }

    private List<Building> PrepareExploreDeck(string set)
    {
        var exploreDeck = new List<Building>();
        exploreDeck.AddRange(_buildingData.GetAll("Explore"));
        _ambushPool.AddRange(_buildingData.GetAndSkipTakenBuildings("Ambush", 1));
        exploreDeck.AddRange(_ambushPool);
        if (set == SetIdentifiers.Heroes)
        {
            _heroesPool.AddRange(_buildingData.GetAndSkipTakenBuildings("Hero", 1));
            exploreDeck.AddRange(_heroesPool);
        }
        exploreDeck.Shuffle();
        return exploreDeck;
    }

    private static void AppendCardData(StringBuilder builder, CardData cardData, bool drawRuins)
    {
        builder.AppendLine();
        builder.AppendLine(cardData.PrintTerrainTypes());
        builder.AppendLine("__________________________________________________________________________________________________________________________");
        builder.AppendLine();
        builder.Append(cardData.PrintShapes(drawRuins));
        builder.Append("[/size][/c][/o]");
        builder.AppendLine();
    }

    private class CardData
    {
        private readonly IEnumerable<TerrainType> _terrainTypes;
        private readonly string _shapeDescription;
        private readonly string _afterScoringEffect;

        public CardData(int time, IEnumerable<TerrainType> terrainTypes, string shapeDescription, string afterScoringEffect = null)
        {
            Time = time;
            _terrainTypes = terrainTypes;
            _shapeDescription = shapeDescription;
            _afterScoringEffect = afterScoringEffect;
        }

        public static CardData Placeholder { get; } = new(0, new[] { TerrainType.None }, $" {NL} {NL} {NL} {NL}");

        public int Time { get; }
        public bool IsMonster => _terrainTypes.Any(p => p == TerrainType.Monster) && _terrainTypes.Count() == 1;
        public bool IsHero => _terrainTypes.Any(p => p == TerrainType.Hero) && _terrainTypes.Count() == 1;

        public bool HasAfterScoringEffect => !string.IsNullOrEmpty(_afterScoringEffect);

        public string PrintTerrainTypes()
        {
            return string.Join("[microbadge=12865]|[microbadge=12865]", _terrainTypes.Select(p =>
            {
                return p switch
                {
                    TerrainType.None => "[microbadge=12865]",
                    TerrainType.Farm => "[microbadge=46466] Farm",
                    TerrainType.Forest => "[microbadge=46467] Forest",
                    TerrainType.Village => "[microbadge=46464] Village",
                    TerrainType.Water => "[microbadge=46465] Water",
                    TerrainType.Monster => "[microbadge=46463] Monster",
                    TerrainType.Hero => "[microbadge=35694] Hero",
                    _ => throw new InvalidOperationException("Unsupported terrain type.")
                };
            }));
        }

        public string AfterScoringEffect => _afterScoringEffect;

        public string PrintShapes(bool drawRuins)
        {
            return ShapeHelper.Print(_shapeDescription, drawRuins);
        }
    }

    private enum TerrainType
    {
        None,
        Farm,
        Forest,
        Village,
        Water,
        Monster,
        Hero
    }

    private class BaseCardData
    {
        public static Dictionary<int, CardData> Generate()
        {
            var _cardData = new Dictionary<int, CardData>();
            _cardData.Add(1, new CardData(1, new[] { TerrainType.Farm },
                $"   |  X{NL}" +
                $"X  | XXX{NL}" +
                $"XG |  X{NL}" +
                $"   |{NL}"));
            _cardData.Add(2, new CardData(2, new[] { TerrainType.Forest, TerrainType.Village },
                $" {NL}" +
                $"  XX{NL}" +
                $"XXX {NL}" +
                $" {NL}"));
            _cardData.Add(3, new CardData(2, new[] { TerrainType.Village, TerrainType.Water },
                $" {NL}" +
                $"XXXX{NL}" +
                $" {NL}" +
                $" {NL}"));
            _cardData.Add(4, new CardData(2, new[] { TerrainType.Village, TerrainType.Farm },
                $"X{NL}" +
                $"XX{NL}" +
                $"X{NL}" +
                $" {NL}"));
            _cardData.Add(5, new CardData(1, new[] { TerrainType.Water },
                $"X  |   X{NL}" +
                $"XG |  XX{NL}" +
                $"X  | XX{NL}" +
                $"   |{NL}"));
            _cardData.Add(6, new CardData(2, new[] { TerrainType.Farm, TerrainType.Water },
                $"XXX{NL}" +
                $"X{NL}" +
                $"X{NL}" +
                $" {NL}"));
            _cardData.Add(7, new CardData(2, new[] { TerrainType.Forest, TerrainType.Farm },
                $" {NL}" +
                $"XXX{NL}" +
                $"  X{NL}" +
                $" {NL}"));
            _cardData.Add(8, new CardData(0,
                new[]
                {
                    TerrainType.Forest, TerrainType.Village, TerrainType.Farm, TerrainType.Water,
                    TerrainType.Monster
                },
                $" {NL}" +
                $"X{NL}" +
                $" {NL}" +
                $" {NL}"));
            _cardData.Add(9, new CardData(2, new[] { TerrainType.Forest, TerrainType.Water },
                $"X{NL}" +
                $"XXX{NL}" +
                $"X{NL}" +
                $" {NL}"));
            _cardData.Add(10, new CardData(1, new[] { TerrainType.Forest },
                $"    | X{NL}" +
                $"X   | XX{NL}" +
                $" XG |  X{NL}" +
                $"    |{NL}"));
            _cardData.Add(11, new CardData(1, new[] { TerrainType.Village },
                $"    |{NL}" +
                $"X   | XXX{NL}" +
                $"XXG | XX{NL}" +
                $"    |{NL}"));
            _cardData.Add(14, new CardData(0, new[] { TerrainType.Monster },
                $"D XX {NL}" +
                $"  X{NL}" +
                $"  XX{NL}" +
                $" {NL}"));
            _cardData.Add(15, new CardData(0, new[] { TerrainType.Monster },
                $"X {NL}" +
                $" X {NL}" +
                $"  X U{NL}" +
                $" {NL}"));
            _cardData.Add(16, new CardData(0, new[] { TerrainType.Monster },
                $"    D{NL}" +
                $"XOX {NL}" +
                $"XOX {NL}" +
                $" {NL}"));
            _cardData.Add(17, new CardData(0, new[] { TerrainType.Monster },
                $"  X{NL}" +
                $"  XX{NL}" +
                $"U X{NL}" +
                $" {NL}"));
            _cardData.Add(34, new CardData(0, new[] { TerrainType.Monster },
                $"    L{NL}" +
                $" X{NL}" +
                $" XX{NL}" +
                $" {NL}"));
            _cardData.Add(35, new CardData(0, new[] { TerrainType.Monster },
                $"R  X{NL}" +
                $"  XX{NL}" +
                $"  X{NL}" +
                $" {NL}"));
            _cardData.Add(36, new CardData(0, new[] { TerrainType.Monster },
                $" {NL}" +
                $" XXX{NL}" +
                $" {NL}" +
                $"    L{NL}"));
            _cardData.Add(37, new CardData(0, new[] { TerrainType.Monster },
                $" {NL}" +
                $" XX{NL}" +
                $" XX{NL}" +
                $"R {NL}"));
            return _cardData;
        }
    }

    private class HeroesCardData
    {
        public static Dictionary<int, CardData> Generate()
        {

            var _cardData = new Dictionary<int, CardData>();
            _cardData.Add(1, new CardData(0, new[] { TerrainType.Hero },
                $" B{NL}" +
                $"BSB{NL}" +
                $" B{NL}" +
                $" {NL}"));
            _cardData.Add(2, new CardData(0, new[] { TerrainType.Hero },
                $"  B{NL}" +
                $"SOB{NL}" +
                $"  B {NL}" +
                $" {NL}"));
            _cardData.Add(3, new CardData(0, new[] { TerrainType.Hero },
                $" {NL}" +
                $"SBBB{NL}" +
                $" {NL}" +
                $" {NL}"));
            _cardData.Add(4, new CardData(0, new[] { TerrainType.Hero },
                $"B B{NL}" +
                $" S{NL}" +
                $"B B{NL}" +
                $" {NL}"));
            _cardData.Add(5, new CardData(1, new[] { TerrainType.Water },
                $"    |   {NL}" +
                $" XG | XXX{NL}" +
                $"X   |  X{NL}" +
                $"    |{NL}"));
            _cardData.Add(6, new CardData(1, new[] { TerrainType.Farm },
                $"     |   {NL}" +
                $"XOXG |  XX{NL}" +
                $"     | XX{NL}" +
                $"     |{NL}"));
            _cardData.Add(7, new CardData(1, new[] { TerrainType.Village },
                $"   |   X{NL}" +
                $"XG |  XX{NL}" +
                $"X  | XX{NL}" +
                $"   |{NL}"));
            _cardData.Add(8, new CardData(1, new[] { TerrainType.Forest },
                $"    |{NL}" +
                $"X G | XOX{NL}" +
                $"XX  | XOX{NL}" +
                $"    |{NL}"));
            _cardData.Add(9, new CardData(2, new[] { TerrainType.Farm, TerrainType.Water },
                $" {NL}" +
                $"XX{NL}" +
                $"XX{NL}" +
                $" {NL}"));
            _cardData.Add(10, new CardData(2, new[] { TerrainType.Village, TerrainType.Farm },
                $"XXX{NL}" +
                $" X{NL}" +
                $" X{NL}" +
                $" {NL}"));
            _cardData.Add(11, new CardData(2, new[] { TerrainType.Forest, TerrainType.Farm },
                $" {NL}" +
                $" XX{NL}" +
                $"X{NL}" +
                $" {NL}"));
            _cardData.Add(12, new CardData(2, new[] { TerrainType.Forest, TerrainType.Village },
                $" X{NL}" +
                $"XXX{NL}" +
                $" X{NL}" +
                $" {NL}"));
            _cardData.Add(13, new CardData(2, new[] { TerrainType.Village, TerrainType.Water },
                $" {NL}" +
                $"XXX{NL}" +
                $"X{NL}" +
                $" {NL}"));
            _cardData.Add(14, new CardData(2, new[] { TerrainType.Forest, TerrainType.Water },
                $" {NL}" +
                $"XXX{NL}" +
                $"X X{NL}" +
                $" {NL}"));
            _cardData.Add(15, new CardData(0, new[] { TerrainType.Forest, TerrainType.Village, TerrainType.Farm, TerrainType.Water, TerrainType.Monster },
                $" {NL}" +
                $" X{NL}" +
                $" {NL}" +
                $" {NL}"));
            _cardData.Add(16, new CardData(0, new[] { TerrainType.Monster },
                $"    X{NL}" +
                $"  XXX   When all spaces of the dragon are{NL}" +
                $"  X     surrounded or destroyed, gain 3 coins.{NL}" +
                $"R {NL}"));
            _cardData.Add(17, new CardData(0, new[] { TerrainType.Monster },
                $"D {NL}" +
                $" X   After scoring each season, draw a zombie in{NL}" +
                $"     each empty space adjacent to a zombie.{NL}" +
                $" {NL}",
                "Draw a Zombie in each empty space adjacent to a Zombie."));
            _cardData.Add(18, new CardData(0, new[] { TerrainType.Monster },
                $"    D{NL}" +
                $"XXX    After scoring each season, destroy an{NL}" +
                $" X     empty space adjacent to the giant troll.{NL}" +
                $" {NL}",
                "Destroy an empty space adjacent to the Giant Troll."));
            _cardData.Add(19, new CardData(0, new[] { TerrainType.Monster },
                $"  {NL}" +
                $"X X   After drawing the gorgon, destroy an{NL}" +
                $" X    adjacent non-mountain space.{NL}" +
                $"    L{NL}"));
            return _cardData;
        }
    }
}

internal static class BuildingExtensions
{
    internal static bool IsRuins(this Building building, string set)
    {
        return set == SetIdentifiers.Base && building.Id is 12 or 13;
    }
}