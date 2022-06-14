using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Utils;

namespace scg.Generators.WelcomeTo
{
    public class ConstructionCardGenerator : TemplateGenerator
    {
        public override string Token { get; } = "<<CONSTRUCTION_CARDS>>";
        public override string Apply(string template, string[] arguments)
        {
            return template.ReplaceFirst(Token, GenerateRandomizedConstructionCards());
        }

        public string GenerateRandomizedConstructionCards()
        {
            var sb = new StringBuilder();

            List<ConstructionCard> allConstructionCards = _initConstructionDeck();
            WelcomeToUtils.Shuffle(allConstructionCards);

            List<ConstructionCard> firstSubDeck = new List<ConstructionCard>();
            List<ConstructionCard> secondSubDeck = new List<ConstructionCard>();

            for (int i = 0; i < 41; i++)
            {
                firstSubDeck.Add(allConstructionCards[i]);
            }

            for (int i = 41; i < 81; i++)
            {
                secondSubDeck.Add(allConstructionCards[i]);
            }

            secondSubDeck.Add(ConstructionCard.Create(0, Figure.SOLO_CARD));
            WelcomeToUtils.Shuffle(secondSubDeck);

            Queue<ConstructionCard> finalDeck = new Queue<ConstructionCard>(firstSubDeck);
            secondSubDeck.ForEach(o => finalDeck.Enqueue(o));

            for (int i = 0; i < Constants.NUM_TURNS; i++)
            {
                ConstructionCard firstCard = _getTopCard(finalDeck, sb);
                ConstructionCard secondCard = _getTopCard(finalDeck, sb);
                ConstructionCard thirdCard = _getTopCard(finalDeck, sb);

                sb.Append(string.Format(
                        Constants.THREE_CARDS,
                        firstCard.Number,
                        Constants.GetFigureForEnum(firstCard.Figure),
                        secondCard.Number,
                        Constants.GetFigureForEnum(secondCard.Figure),
                        thirdCard.Number,
                        Constants.GetFigureForEnum(thirdCard.Figure)));
            }

            return sb.ToString();
        }

        private ConstructionCard _getTopCard(Queue<ConstructionCard> finalDeck, StringBuilder sb)
        {
            ConstructionCard topCard = finalDeck.Dequeue();

            if (topCard.Figure == Figure.SOLO_CARD)
            {
                sb.Append(Constants.SOLO_CARD);
                topCard = finalDeck.Dequeue();
            }

            return topCard;
        }

        private List<ConstructionCard> _initConstructionDeck()
        {
            return new List<ConstructionCard> {
                        ConstructionCard.Create(1, Figure.GREEN),
                        ConstructionCard.Create(2, Figure.GREEN),
                        ConstructionCard.Create(4, Figure.GREEN),
                        ConstructionCard.Create(5, Figure.GREEN),
                        ConstructionCard.Create(5, Figure.GREEN),
                        ConstructionCard.Create(6, Figure.GREEN),
                        ConstructionCard.Create(7, Figure.GREEN),
                        ConstructionCard.Create(7, Figure.GREEN),
                        ConstructionCard.Create(8, Figure.GREEN),
                        ConstructionCard.Create(8, Figure.GREEN),
                        ConstructionCard.Create(9, Figure.GREEN),
                        ConstructionCard.Create(9, Figure.GREEN),
                        ConstructionCard.Create(10, Figure.GREEN),
                        ConstructionCard.Create(11, Figure.GREEN),
                        ConstructionCard.Create(11, Figure.GREEN),
                        ConstructionCard.Create(12, Figure.GREEN),
                        ConstructionCard.Create(14, Figure.GREEN),
                        ConstructionCard.Create(15, Figure.GREEN),

                        ConstructionCard.Create(1, Figure.GRAY),
                        ConstructionCard.Create(2, Figure.GRAY),
                        ConstructionCard.Create(3, Figure.GRAY),
                        ConstructionCard.Create(5, Figure.GRAY),
                        ConstructionCard.Create(5, Figure.GRAY),
                        ConstructionCard.Create(6, Figure.GRAY),
                        ConstructionCard.Create(6, Figure.GRAY),
                        ConstructionCard.Create(7, Figure.GRAY),
                        ConstructionCard.Create(8, Figure.GRAY),
                        ConstructionCard.Create(8, Figure.GRAY),
                        ConstructionCard.Create(9, Figure.GRAY),
                        ConstructionCard.Create(10, Figure.GRAY),
                        ConstructionCard.Create(10, Figure.GRAY),
                        ConstructionCard.Create(11, Figure.GRAY),
                        ConstructionCard.Create(11, Figure.GRAY),
                        ConstructionCard.Create(13, Figure.GRAY),
                        ConstructionCard.Create(14, Figure.GRAY),
                        ConstructionCard.Create(15, Figure.GRAY),

                        ConstructionCard.Create(3, Figure.BLUE),
                        ConstructionCard.Create(4, Figure.BLUE),
                        ConstructionCard.Create(6, Figure.BLUE),
                        ConstructionCard.Create(7, Figure.BLUE),
                        ConstructionCard.Create(8, Figure.BLUE),
                        ConstructionCard.Create(9, Figure.BLUE),
                        ConstructionCard.Create(10, Figure.BLUE),
                        ConstructionCard.Create(12, Figure.BLUE),
                        ConstructionCard.Create(13, Figure.BLUE),

                        ConstructionCard.Create(1, Figure.PURPLE),
                        ConstructionCard.Create(2, Figure.PURPLE),
                        ConstructionCard.Create(4, Figure.PURPLE),
                        ConstructionCard.Create(5, Figure.PURPLE),
                        ConstructionCard.Create(5, Figure.PURPLE),
                        ConstructionCard.Create(6, Figure.PURPLE),
                        ConstructionCard.Create(7, Figure.PURPLE),
                        ConstructionCard.Create(7, Figure.PURPLE),
                        ConstructionCard.Create(8, Figure.PURPLE),
                        ConstructionCard.Create(8, Figure.PURPLE),
                        ConstructionCard.Create(9, Figure.PURPLE),
                        ConstructionCard.Create(9, Figure.PURPLE),
                        ConstructionCard.Create(10, Figure.PURPLE),
                        ConstructionCard.Create(11, Figure.PURPLE),
                        ConstructionCard.Create(11, Figure.PURPLE),
                        ConstructionCard.Create(12, Figure.PURPLE),
                        ConstructionCard.Create(14, Figure.PURPLE),
                        ConstructionCard.Create(15, Figure.PURPLE),

                        ConstructionCard.Create(3, Figure.ORANGE),
                        ConstructionCard.Create(4, Figure.ORANGE),
                        ConstructionCard.Create(6, Figure.ORANGE),
                        ConstructionCard.Create(7, Figure.ORANGE),
                        ConstructionCard.Create(8, Figure.ORANGE),
                        ConstructionCard.Create(9, Figure.ORANGE),
                        ConstructionCard.Create(10, Figure.ORANGE),
                        ConstructionCard.Create(12, Figure.ORANGE),
                        ConstructionCard.Create(13, Figure.ORANGE),

                        ConstructionCard.Create(3, Figure.RED),
                        ConstructionCard.Create(4, Figure.RED),
                        ConstructionCard.Create(6, Figure.RED),
                        ConstructionCard.Create(7, Figure.RED),
                        ConstructionCard.Create(8, Figure.RED),
                        ConstructionCard.Create(9, Figure.RED),
                        ConstructionCard.Create(10, Figure.RED),
                        ConstructionCard.Create(12, Figure.RED),
                        ConstructionCard.Create(13, Figure.RED)
                    };
        }
    }
}