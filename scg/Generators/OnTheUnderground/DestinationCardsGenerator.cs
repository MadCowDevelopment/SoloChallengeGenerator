using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Framework;
using scg.Utils;

namespace scg.Generators.OnTheUnderground
{
    public class DestinationCardsGenerator : TemplateGenerator
    {
        private readonly GameOptions _gameOptions;
        private List<DestinationDeck> _destinationDecks;
        private string _map;

        public DestinationCardsGenerator(GameOptions gameOptions)
        {
            _gameOptions = gameOptions;
        }

        public override string Token { get; } = "<<DESTINATION_CARDS>>";

        public override string Apply(string template, string[] arguments)
        {
            var rounds = int.Parse(arguments.Length < 1 ? "1" : arguments[0]);
            InitializedDestinationDecks(rounds);
            return template.Replace(Token, CreateTemplateString());
        }

        private void InitializedDestinationDecks(int rounds)
        {
            _destinationDecks = new List<DestinationDeck>();
            var factory = ChooseFactory();
            for (int i = 0; i < rounds; i++)
            {
                _destinationDecks.Add(factory.Create());
            }
        }

        private IDestinationDeckFactory ChooseFactory()
        {
            return Map switch
            {
                "London" => new LondonDestinationDeckFactory(),
                "Berlin" => new BerlinDestinationDeckFactory(),
                _ => throw new InvalidOperationException($"Map '{Map}' is not supported.")
            };
        }

        private string Map => _map ??= _gameOptions.Options["Map"];

        private string CreateTemplateString()
        {
            var longestName = _destinationDecks[0].Destinations.Max(p => p.Name.Length);

            var builder = new StringBuilder();
            builder.AppendLine(CreateRoundHeader(longestName));

            for (var i = 54; i > 0; i--)
            {
                builder.AppendLine(string.Join("   ",
                    _destinationDecks.Select(p => CreateDestinationEntry(p, i, longestName))));
            }

            var footer = CreateFooter(longestName);
            builder.AppendLine(CreateFooter(longestName));
            return builder.ToString();
        }

        private string CreateRoundHeader(int longestName)
        {
            var headers = new List<string>();
            for (var i = 1; i <= _destinationDecks.Count; i++)
            {
                var header = $"    Round {i}";
                if (i == 1) header += " (main event)";
                var whitespaces = string.Join("", Enumerable.Repeat(" ", longestName - header.Length + 10));
                headers.Add($"[b]{header}{whitespaces}[/b]");
            }

            return string.Join("   ", headers);
        }

        private static string CreateDestinationEntry(DestinationDeck destinationDeck, int i, int longestName)
        {
            var card = destinationDeck.Destinations[i];
            var number = $"{i + 1:D2}".ReplaceLeading("0", " ");
            var color = card.RouteType == RouteType.Express ? "FFDF00" : "ADADAD";
            var whitespaces = string.Join("", Enumerable.Repeat(" ", longestName - card.Name.Length));
            return $"{number}: [o][BGCOLOR=#{color}]{card.Region} - {card.Name}{whitespaces}[/BGCOLOR][/o]";
        }

        private string CreateFooter(int longestName)
        {
            const string sorryText = "I'm sorry, you've lost!";
            var whitespaces = string.Join("", Enumerable.Repeat(" ", longestName - sorryText.Length + 5));
            return string.Join("   ",
                Enumerable.Repeat($" 1: [o][BGCOLOR=#FF3333]{sorryText}{whitespaces}[/BGCOLOR][/o]",
                    _destinationDecks.Count));
        }
    }
}
