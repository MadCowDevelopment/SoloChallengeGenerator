using System.Text;
using scg.Utils;

namespace scg.Generators.RollingRealms;

public class RollingRealmsRollsGenerator : TemplateGenerator
{
    public override string Token { get; } = "<<ROLLINGREALMS_ROLLS>>";
    public override string Apply(string template, string[] arguments)
    {
        return template.ReplaceFirst(Token, CreateRandomizedTiles());
    }

    private string CreateRandomizedTiles()
    {
        var builder = new StringBuilder();
        builder.Append("[c]");

        for (var turn = 1; turn <= 9; turn++)
        {
            builder.Append($"Turn {turn}: ");
            builder.Append($"[o]{RNG.Between(1, 6)}, {RNG.Between(1, 6)}[/o] ");
            if (turn is 3 or 6) builder.AppendLine();
        }

        builder.AppendLine("      [/c]");

        return builder.ToString();
    }
}