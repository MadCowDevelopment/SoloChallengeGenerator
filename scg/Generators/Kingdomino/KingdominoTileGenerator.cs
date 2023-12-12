using System.Linq;
using System.Text;
using scg.Utils;

namespace scg.Generators.Kingdomino;

public class KingdominoTileGenerator : TemplateGenerator
{
    public override string Token { get; } = "<<KINGDOMINO_TILES>>";
    public override string Apply(string template, string[] arguments)
    {
        return template.ReplaceFirst(Token, CreateRandomizedTiles());
    }

    private string CreateRandomizedTiles()
    {
        var builder = new StringBuilder();
        var numbers = Enumerable.Range(1, 48).ToList();
        numbers.Shuffle();

        for (int gameNumber = 0; gameNumber < 2; gameNumber++)
        {
            builder.AppendLine($"[b]Game {gameNumber+1}[/b]");
            for (int setNumber = 0; setNumber < 6; setNumber++)
            {
                builder.AppendLine($"Set {setNumber + 1}:");
                builder.Append("[o][c]");
                builder.Append(string.Join(", ", numbers.Skip(gameNumber * 24 + setNumber * 4).Take(4).OrderBy(p=>p).Select(n => $"{n}".PadLeft(2, ' '))));
                builder.AppendLine("[/c][/o]");
            }

            builder.AppendLine();
            builder.AppendLine();
        }

        return builder.ToString();
    }
}