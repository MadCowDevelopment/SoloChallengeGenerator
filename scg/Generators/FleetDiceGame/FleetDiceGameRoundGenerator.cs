using System;
using System.Linq;
using System.Text;
using scg.Utils;

namespace scg.Generators.FleetDiceGame
{
    public class FleetDiceGameRoundGenerator : TemplateGenerator
    {
        private Random _rand = new Random();

        private string _emptyLine = "[size=15][microbadge=3][/size][b][size=15][color=#a5a351][/color][/size][/b]";
        public override string Token { get; } = "<<FLEET_ROUNDS>>";
        public override string Apply(string template, string[] arguments)
        {
            return template.ReplaceFirst(Token, CreateRandomizedDice());
        }

        public string CreateRandomizedDice()
        {
            var builder = new StringBuilder();
            var maxRound = 8;
            
            _generateBaseBoatDie(builder);

            for(int i = 0; i < maxRound; i++) {
                bool isEven = (i + 1) % 2 == 0;
                string firstPlayer = isEven ? "Captain Ruth" : "You";
                builder.AppendLine($"[size=15][u][b]Round {i + 1} - First Player: {firstPlayer}[/b][/u][/size]");
                builder.AppendLine(_emptyLine);
                builder.Append("[o][c]");
                builder.AppendLine("[size=12][b]Boat Phase[/b][/size]");

                _generateBoatDice(builder);
                builder.AppendLine("[/c][/o]");
                builder.Append("[o][c]");
                builder.AppendLine("[size=12][b]Town Phase[/b][/size]");

                _generateTownDice(builder);

                builder.AppendLine("[/c][/o]");
                
            }

            return builder.ToString();
        }

       private void _generateBaseBoatDie(StringBuilder sb) {
            int randNum = _rand.Next(0, 5);
            string currStr = _getBoatSideForNum(randNum);
            
            sb.Append("[o][c]");
            sb.AppendLine("[size=12][b]Base Boat Die[/b][/size]");
            sb.Append($"{currStr} ");
            sb.AppendLine("[/c][/o]");
        }

        private void _generateBoatDice(StringBuilder sb) {
            for(int i = 0; i < 3; i++) {
                int randNum = _rand.Next(0, 6);
                string currStr = _getBoatSideForNum(randNum);
                sb.Append($"{currStr} ");
            }

            sb.AppendLine(_emptyLine);
        }

        private void _generateTownDice(StringBuilder sb) {
            for(int i = 0; i < 2; i++) {
                int randNum = _rand.Next(0, 3);
                string currStr = _getTownSideForNum(randNum);
                sb.Append($"{currStr} ");
            }

            int num = _rand.Next(0, 6);
            sb.Append(_getBoatSideForNum(num));
            sb.AppendLine(_emptyLine);
        }

        private string _getBoatSideForNum(int num) {
            switch(num) {
                case 0:
                    return "[imageid=6916600 inline]";
                case 1:
                    return "[imageid=6916602 inline]";
                case 2:
                    return "[imageid=6916603 inline]";
                case 3:
                    return "[imageid=6916604 inline]";
                case 4:
                    return "[imageid=6916605 inline]";
                case 5:
                    return "[imageid=6916606 inline]";
                default:
                    return "[imageid=6916600 inline]";    
            }
        }

        private string _getTownSideForNum(int num) {
            switch(num) {
                case 0:
                    return "[imageid=6916607 inline]";
                case 1:
                    return "[imageid=6916608 inline]";
                case 2:
                    return "[imageid=6916609 inline]";
                default:
                    return "[imageid=6916607 inline]";    
            }
        }
    }
}