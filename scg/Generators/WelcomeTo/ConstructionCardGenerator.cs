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

        private string GenerateRandomizedConstructionCards()
        {
            var sb = new StringBuilder();

            List<ConstructionCard> allConstructionCards = initConstructionDeck();
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

            secondSubDeck.Add(ConstructionCard.create(0, Figure.SOLO_CARD));
            WelcomeToUtils.Shuffle(secondSubDeck);

            Queue<ConstructionCard> finalDeck = new Queue<ConstructionCard>(firstSubDeck);
            secondSubDeck.ForEach(o => finalDeck.Enqueue(o));

            for (int i = 0; i < Constants.NUM_TURNS; i++)
            {
                ConstructionCard firstCard = getTopCard(finalDeck, sb);
                ConstructionCard secondCard = getTopCard(finalDeck, sb);
                ConstructionCard thirdCard = getTopCard(finalDeck, sb);

                sb.Append(string.Format(
                        Constants.THREE_CARDS,
                        firstCard.number,
                        Constants.getFigureForEnum(firstCard.figure),
                        secondCard.number,
                        Constants.getFigureForEnum(secondCard.figure),
                        thirdCard.number,
                        Constants.getFigureForEnum(thirdCard.figure)));
            }

            return sb.ToString();
        }

        private ConstructionCard getTopCard(Queue<ConstructionCard> finalDeck, StringBuilder sb)
        {
            ConstructionCard topCard = finalDeck.Dequeue();

            if (topCard.figure == Figure.SOLO_CARD)
            {
                sb.Append(Constants.SOLO_CARD);
                topCard = finalDeck.Dequeue();
            }

            return topCard;
        }

        private List<ConstructionCard> initConstructionDeck()
        {
            return new List<ConstructionCard> {
                        ConstructionCard.create(1, Figure.GREEN),
                        ConstructionCard.create(2, Figure.GREEN),
                        ConstructionCard.create(4, Figure.GREEN),
                        ConstructionCard.create(5, Figure.GREEN),
                        ConstructionCard.create(5, Figure.GREEN),
                        ConstructionCard.create(6, Figure.GREEN),
                        ConstructionCard.create(7, Figure.GREEN),
                        ConstructionCard.create(7, Figure.GREEN),
                        ConstructionCard.create(8, Figure.GREEN),
                        ConstructionCard.create(8, Figure.GREEN),
                        ConstructionCard.create(9, Figure.GREEN),
                        ConstructionCard.create(9, Figure.GREEN),
                        ConstructionCard.create(10, Figure.GREEN),
                        ConstructionCard.create(11, Figure.GREEN),
                        ConstructionCard.create(11, Figure.GREEN),
                        ConstructionCard.create(12, Figure.GREEN),
                        ConstructionCard.create(14, Figure.GREEN),
                        ConstructionCard.create(15, Figure.GREEN),

                        ConstructionCard.create(1, Figure.GRAY),
                        ConstructionCard.create(2, Figure.GRAY),
                        ConstructionCard.create(3, Figure.GRAY),
                        ConstructionCard.create(5, Figure.GRAY),
                        ConstructionCard.create(5, Figure.GRAY),
                        ConstructionCard.create(6, Figure.GRAY),
                        ConstructionCard.create(6, Figure.GRAY),
                        ConstructionCard.create(7, Figure.GRAY),
                        ConstructionCard.create(8, Figure.GRAY),
                        ConstructionCard.create(8, Figure.GRAY),
                        ConstructionCard.create(9, Figure.GRAY),
                        ConstructionCard.create(10, Figure.GRAY),
                        ConstructionCard.create(10, Figure.GRAY),
                        ConstructionCard.create(11, Figure.GRAY),
                        ConstructionCard.create(11, Figure.GRAY),
                        ConstructionCard.create(13, Figure.GRAY),
                        ConstructionCard.create(14, Figure.GRAY),
                        ConstructionCard.create(15, Figure.GRAY),

                        ConstructionCard.create(3, Figure.BLUE),
                        ConstructionCard.create(4, Figure.BLUE),
                        ConstructionCard.create(6, Figure.BLUE),
                        ConstructionCard.create(7, Figure.BLUE),
                        ConstructionCard.create(8, Figure.BLUE),
                        ConstructionCard.create(9, Figure.BLUE),
                        ConstructionCard.create(10, Figure.BLUE),
                        ConstructionCard.create(12, Figure.BLUE),
                        ConstructionCard.create(13, Figure.BLUE),

                        ConstructionCard.create(1, Figure.PURPLE),
                        ConstructionCard.create(2, Figure.PURPLE),
                        ConstructionCard.create(4, Figure.PURPLE),
                        ConstructionCard.create(5, Figure.PURPLE),
                        ConstructionCard.create(5, Figure.PURPLE),
                        ConstructionCard.create(6, Figure.PURPLE),
                        ConstructionCard.create(7, Figure.PURPLE),
                        ConstructionCard.create(7, Figure.PURPLE),
                        ConstructionCard.create(8, Figure.PURPLE),
                        ConstructionCard.create(8, Figure.PURPLE),
                        ConstructionCard.create(9, Figure.PURPLE),
                        ConstructionCard.create(9, Figure.PURPLE),
                        ConstructionCard.create(10, Figure.PURPLE),
                        ConstructionCard.create(11, Figure.PURPLE),
                        ConstructionCard.create(11, Figure.PURPLE),
                        ConstructionCard.create(12, Figure.PURPLE),
                        ConstructionCard.create(14, Figure.PURPLE),
                        ConstructionCard.create(15, Figure.PURPLE),

                        ConstructionCard.create(3, Figure.ORANGE),
                        ConstructionCard.create(4, Figure.ORANGE),
                        ConstructionCard.create(6, Figure.ORANGE),
                        ConstructionCard.create(7, Figure.ORANGE),
                        ConstructionCard.create(8, Figure.ORANGE),
                        ConstructionCard.create(9, Figure.ORANGE),
                        ConstructionCard.create(10, Figure.ORANGE),
                        ConstructionCard.create(12, Figure.ORANGE),
                        ConstructionCard.create(13, Figure.ORANGE),

                        ConstructionCard.create(3, Figure.RED),
                        ConstructionCard.create(4, Figure.RED),
                        ConstructionCard.create(6, Figure.RED),
                        ConstructionCard.create(7, Figure.RED),
                        ConstructionCard.create(8, Figure.RED),
                        ConstructionCard.create(9, Figure.RED),
                        ConstructionCard.create(10, Figure.RED),
                        ConstructionCard.create(12, Figure.RED),
                        ConstructionCard.create(13, Figure.RED)
                    };
        }
    }
}