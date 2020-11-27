using System.Linq;
using System.Text;
using scg.Utils;

namespace scg.Generators.OnTheUnderground
{
    public class DestinationCardsGenerator : TemplateGenerator
    {
        private readonly DestinationDeck _destinationDeck;

        public DestinationCardsGenerator()
        {
            _destinationDeck = new DestinationDeckFactory().Create();
        }

        public override string Token { get; } = "<<DESTINATION_CARDS>>";
        public override string Apply(string template, string[] arguments)
        {
            var builder = new StringBuilder();
            var longestName = _destinationDeck.Destinations.Max(p => p.Name.Length);
            for (var i = 54; i > 0; i--)
            {
                var card = _destinationDeck.Destinations[i];
                var number = $"{i+1:D2}".ReplaceLeading("0", " ");
                var color = card.RouteType == RouteType.Express ? "FFDF00" : "ADADAD";
                var whitespaces = string.Join("", Enumerable.Repeat(" ", longestName - card.Name.Length));
                builder.AppendLine($"{number}: [o][BGCOLOR=#{color}]{card.Region} - {card.Name}{whitespaces}[/BGCOLOR][/o]");
            }

            return template.Replace(Token, builder.ToString());
        }
    }
}
