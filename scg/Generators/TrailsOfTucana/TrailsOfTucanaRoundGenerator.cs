using System;
using System.Collections.Generic;
using System.Text;
using scg.Utils;

namespace scg.Generators.TrailsOfTucana;

public class TrailsOfTucanaRoundGenerator : TemplateGenerator
{
    private Random _rand = new Random();

    private string _emptyLine = "[size=15][microbadge=3][/size][b][size=15][color=#a5a351][/color][/size][/b]";

    private List<string[]> _setupLetters = new List<string[]>
    {
        new string[]{"D", "B", "A", "C", "E", "C", "D", "A", "E", "B"},
        new string[]{"B", "D", "C", "A", "E", "B", "E", "D", "C", "A"},
        new string[]{"B", "A", "C", "B", "D", "C", "E", "A", "E", "D"},
        new string[]{"D", "A", "D", "B", "A", "E", "C", "E", "C", "B"},
        new string[]{"D", "C", "E", "A", "D", "C", "B", "A", "E", "B"},
        new string[]{"C", "E", "B", "A", "E", "D", "C", "D", "A", "B"},
        new string[]{"A", "D", "C", "B", "D", "A", "C", "E", "B", "E"},
        new string[]{"B", "E", "D", "C", "B", "A", "D", "E", "C", "A"},
        new string[]{"E", "C", "A", "E", "B", "D", "A", "B", "D", "C"},
        new string[]{"E", "B", "D", "B", "A", "C", "A", "E", "C", "D"},
        new string[]{"E", "A", "D", "B", "C", "E", "B", "D", "A", "C"},
        new string[]{"C", "A", "E", "C", "B", "A", "D", "E", "B", "D"},
        new string[]{"A", "C", "B", "D", "C", "D", "E", "B", "A", "E"},
    };

    private List<string> _blueBonusLetters = new List<string>
    {
        "A", "B", "C", "D", "E"
    };

    public override string Token { get; } = "<<TUCANA_ROUNDS>>";
    public override string Apply(string template, string[] arguments)
    {
        return template.ReplaceFirst(Token, CreateRandomizedCards());
    }

    public string CreateRandomizedCards()
    {
        var builder = new StringBuilder();
        // Isla Petit = 2; Isla Grande = 3
        var maxRound = 2;
            
        _generateSetupCards(builder);

        for(int i = 0; i < maxRound; i++) {
            builder.AppendLine($"[size=13][u][b]Round {i + 1}[/b][/u][/size]");
            builder.AppendLine(_emptyLine);
                
            _generateRound(builder);

            if(i == 0) {
                // discard blue cards at the end of 1st round
                _generateBlueCardsToDiscard(builder);
            }
        }

        return builder.ToString();
    }

    private void _generateSetupCards(StringBuilder sb) {
        int randNum = _rand.Next(0, 5);
        _setupLetters.Shuffle();

        string[] letters = _setupLetters[0];

        sb.AppendLine("[size=13][u][b]Setup Card[/b][/u][/size]");
        sb.Append("[o][c][size=12][b]");
        for(int i = 0; i < letters.Length; i++) {
            sb.Append($"{i + 1}.");
            sb.Append($"{letters[i]} ");
        }
            
        sb.AppendLine(_emptyLine);
        sb.AppendLine("[/b][/size][/c][/o]");
        sb.AppendLine(_emptyLine);
    }

    private void _generateRound(StringBuilder sb) {
        Queue<int> deck = _generateCardDeck();

        // 13 turns
        for(int i = 0; i < 13; i++) {
            sb.Append("[o][c]");
            string firstCard = _getCardForNum(deck.Dequeue());
            string secondCard = _getCardForNum(deck.Dequeue());
            sb.Append($"{firstCard} ");
            sb.Append($"{secondCard} ");
            sb.Append("[/c][/o]");
        }

        sb.AppendLine(_emptyLine);
    }

    private void _generateBlueCardsToDiscard(StringBuilder sb) {
        _blueBonusLetters.Shuffle();

        sb.Append("[o][c][b][size=13]");
        sb.AppendLine("Blue Bonus Cards to Discard (only if they are not yet completed)");
        sb.Append($"{_blueBonusLetters[0]} ");
        sb.Append($"{_blueBonusLetters[1]} ");
        sb.Append($"{_blueBonusLetters[2]} ");
        sb.AppendLine(_emptyLine);
        sb.AppendLine("[/size][/b][/c][/o]");
    }

    private Queue<int> _generateCardDeck()
    {
        List<int> cardDeck = new List<int>();

        // Desert cards
        for (int i = 0; i < 8; i++)
        {
            cardDeck.Add(0);
        }
        // Forest cards
        for (int i = 0; i < 7; i++)
        {
            cardDeck.Add(1);
        }
        // Mountain cards
        for (int i = 0; i < 6; i++)
        {
            cardDeck.Add(2);
        }
        // Water cards
        for (int i = 0; i < 4; i++)
        {
            cardDeck.Add(3);
        }
        // Wild cards
        for (int i = 0; i < 2; i++)
        {
            cardDeck.Add(4);
        }

        cardDeck.Shuffle();

        // remove 1 card
        cardDeck.Remove(0);

        return new Queue<int>(cardDeck);
    }

    private string _getCardForNum(int num) {
        switch(num) {
            case 0:
                return "[imageid=6941874 inline]";
            case 1:
                return "[imageid=6941876 inline]";
            case 2:
                return "[imageid=6941879 inline]";
            case 3:
                return "[imageid=6941838 inline]";
            case 4:
                return "[imageid=6941880 inline]";
            default:
                return "";
        }
    }
}