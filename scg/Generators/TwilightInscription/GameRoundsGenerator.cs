using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Framework;
using scg.Utils;

namespace scg.Generators.TwilightInscription;

public class GameRoundsGenerator : TemplateGenerator
{
    private readonly BuildingData _data;
    public override string Token => "<<GAME_ROUNDS>>";

    public GameRoundsGenerator(BuildingData data)
    {
        _data = data;
    }

    public override string Apply(string template, string[] arguments)
    {
        var builder = new StringBuilder();

        foreach (var card in CreateEventDeck())
        {
            builder.AppendLine($"[b]Stage {card.FormatStage()}[/b]");
            builder.AppendLine($"{card.ToPost()}");
        }

        return template.Replace(Token, builder.ToString());
    }

    private List<EventCard> CreateEventDeck()
    {
        var availableCards = new List<EventCard>();
        availableCards.Add(new StrategyEventCard { CardData = _data.GetById(1), Color = "blue", Stage = 1, Resources = { "Material", "Material", "Material" } });
        availableCards.Add(new StrategyEventCard { CardData = _data.GetById(2), Color = "blue", Stage = 1, Resources = { "Influence", "Influence" } });
        availableCards.Add(new StrategyEventCard { CardData = _data.GetById(3), Color = "black", Stage = 1, Resources = { "Material", "Influence", "Research" } });
        availableCards.Add(new WarEventCard { CardData = _data.GetById(4), Color = "blue", Stage = 2 });
        availableCards.Add(new CouncilEventCard(GetAgendas(2)) { CardData = _data.GetById(5), Color = "blue", Stage = 2 });
        availableCards.Add(new ProductionEventCard { CardData = _data.GetById(6), Color = "blue", Stage = 2 });
        availableCards.Add(new StrategyEventCard { CardData = _data.GetById(7), Color = "black", Stage = 2, Resources = { "Research" } });
        availableCards.Add(new StrategyEventCard { CardData = _data.GetById(8), Color = "black", Stage = 2, Resources = { "Influence", "Influence" } });
        availableCards.Add(new StrategyEventCard {CardData = _data.GetById(9), Color = "black", Stage = 2, Resources = { "Material", "Material", "Material" } });
        availableCards.Add(new WarEventCard { CardData = _data.GetById(10), Color = "blue", Stage = 3});
        availableCards.Add(new CouncilEventCard(GetAgendas(3)) { CardData = _data.GetById(11), Color = "blue", Stage = 3 });
        availableCards.Add(new ProductionEventCard { CardData = _data.GetById(12), Color = "blue", Stage = 3 });
        availableCards.Add(new StrategyEventCard { CardData = _data.GetById(13), Color = "black", Stage = 3, Resources = { "Material", "Material", "Material" } });
        availableCards.Add(new StrategyEventCard { CardData = _data.GetById(14), Color = "black", Stage = 3, Resources = { "Influence", "Influence" } });
        availableCards.Add(new StrategyEventCard { CardData = _data.GetById(15), Color = "black", Stage = 3, Resources = { "Research" } });
        availableCards.Add(new ProductionEventCard { CardData = _data.GetById(16), Color = "blue", Stage = 4 });
        availableCards.Add(new WarEventCard { CardData = _data.GetById(17), Color = "blue", Stage = 4 });
        availableCards.Add(new CouncilEventCard(GetAgendas(4)) { CardData = _data.GetById(18), Color = "blue", Stage = 4 });
        availableCards.Add(new StrategyEventCard { CardData = _data.GetById(19), Color = "black", Stage = 4, Resources = { "Influence", "Influence" } });
        availableCards.Add(new StrategyEventCard { CardData = _data.GetById(20), Color = "black", Stage = 4, Resources = { "Material", "Material", "Material" } });
        availableCards.Add(new StrategyEventCard { CardData = _data.GetById(21), Color = "black", Stage = 4, Resources = { "Research" } });
        availableCards.Add(new SpecialEventCard { CardData = _data.GetById(22), Color = "blue", Stage = 5});
        availableCards.Add(new WarEventCard { CardData = _data.GetById(23), Color = "blue", Stage = 5 });
        availableCards.Add(new StrategyEventCard { CardData = _data.GetById(24), Color = "black", Stage = 5, Resources = { "Influence", "Influence" } });
        availableCards.Add(new StrategyEventCard { CardData = _data.GetById(25), Color = "black", Stage = 5, Resources = { "Material", "Material", "Material" } });

        var eventDeck = new List<EventCard>();

        var currentColor = "blue";
        var currentStage = 1;
        while (availableCards.Any())
        {
            var candidates = availableCards.Where(p => p.Color == currentColor && p.Stage == currentStage).ToList();
            candidates.Shuffle();
            var chosenCard = candidates.First();
            eventDeck.Add(chosenCard);
            availableCards.Remove(chosenCard);

            currentColor = currentColor == "blue" ? "black" : "blue";

            if (availableCards.All(p => p.Stage != currentStage)) currentStage++;
        }

        return eventDeck;
    }

    private string[] GetAgendas(int stage)
    {
        var allAgendasInStage = _data.GetAndSkipTakenBuildings("Agenda", new[] { stage.ToString() }, 4).ToList();
        for (var i = 1; i < 4; i++)
        {
            if (allAgendasInStage[i].Id % 2 != allAgendasInStage[0].Id % 2)
            {
                return new[] { allAgendasInStage[0].ToPostFormat(), allAgendasInStage[i].ToPostFormat() };
            }
        }

        throw new InvalidOperationException("Didn't find suitable agendas.");
    }

    private abstract class EventCard
    {

        public virtual string ToPost()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"[o][c][b]{Type}:[/b] {CardData.ToPostFormat()}");
            builder.AppendLine("___________________________________________________________________");
            builder.Append($"{Description}[/c][/o]");
            return builder.ToString();
        }

        public Building CardData { get; init; }
        public abstract string Type { get; }
        public abstract string Description { get; }
        public int Stage { get; init; }
        public string Color { get; init; }

        public string FormatStage() => Stage switch
        {
            1 => "I",
            2 => "II",
            3 => "III",
            4 => "IV",
            5 => "V",
            _ => throw new InvalidOperationException()
        };
    }

    private class StrategyEventCard : EventCard
    {
        public override string ToPost()
        {
            var cardResources = string.Join("", Resources.Select(DiceHelper.GetCardResource));
            return $"[o][c]{cardResources} [b]{Type}:[/b] {CardData.ToPostFormat()}[o]{DiceHelper.RollAllDice()}[/o][/c][/o]";
        }

        public override string Type => "Strategy";
        public override string Description => string.Empty;

        public List<string> Resources { get; } = new();
    }

    private class WarEventCard : EventCard
    {
        public override string Type => "War";
        public override string Description => "Advance the deployment line.\nThen resolve a war against the AI.";
    }

    private class ProductionEventCard : EventCard
    {
        public override string Type => "Production";
        public override string Description => "Claim 1 trade good for each unlocked\n+1 trade good icon in your industry chart.";
    }

    private class CouncilEventCard : EventCard
    {
        private string PassAgenda { get; }
        private string FailAgenda { get; }

        public CouncilEventCard(string[]  agendas)
        {
            PassAgenda = agendas[0];
            FailAgenda = agendas[1];
        }

        public override string Type => "Council";
        public override string Description => $"Pass Agenda: {PassAgenda}\nFail Agenda: {FailAgenda}";
    }

    private class SpecialEventCard : EventCard
    {
        public override string Type => "Special";
        public override string Description => "Skip this round.\nThe game will have one more strategy event.";
    }

    private static class DiceHelper
    {
        private static readonly Dictionary<string, string> DieFaces = new()
        {
            {"Black_Material", "7074968"},
            {"Black_Influence", "7074967"},
            {"Black_Research", "7074969"},
            {"Focus_Material_1", "7074972"},
            {"Focus_Influence_1", "7074970"},
            {"Focus_Research_1", "7074974"},
            {"Focus_Material_2", "7074973"},
            {"Focus_Influence_2", "7074971"},
            {"Focus_Research_2", "7074975"},
        };

        private static readonly List<string> BlackDie = new()
        {
            "Black_Material", "Black_Material", "Black_Material", "Black_Influence", "Black_Influence", "Black_Research"
        };

        private static readonly List<string> MaterialDie = new()
        {
            "Focus_Material_1", "Focus_Material_1", "Focus_Material_1", "Focus_Material_1", "Focus_Material_2", "Focus_Material_2"
        };

        private static readonly List<string> InfluenceDie = new()
        {
            "Focus_Influence_1", "Focus_Influence_1", "Focus_Influence_1", "Focus_Influence_1", "Focus_Influence_2", "Focus_Influence_2"
        };

        private static readonly List<string> ResearchDie = new()
        {
            "Focus_Research_1", "Focus_Research_1", "Focus_Research_1", "Focus_Research_1", "Focus_Research_2", "Focus_Research_2"
        };

        public static string RollAllDice()
        {
            var builder = new StringBuilder();
            builder.Append(RollDie(BlackDie));
            builder.Append(RollDie(BlackDie));
            builder.Append(RollDie(BlackDie));
            builder.Append(RollDie(MaterialDie));
            builder.Append(RollDie(InfluenceDie));
            builder.Append(RollDie(ResearchDie));
            return builder.ToString();
        }

        private static string RollDie(List<string> dieFaces)
        {
            dieFaces.Shuffle();
            return FormatImage(DieFaces[dieFaces[0]]);
        }

        public static string GetCardResource(string resourceType)
        {
            var imageId = DieFaces[$"Focus_{resourceType}_1"];
            return FormatImage(imageId);
        }

        private static string FormatImage(string imageId)
        {
            return $"[ImageID={imageId} square inline]";
        }
    }
}