using scg.Utils;

namespace scg.Generators;

public class RandomNumberGenerator : TemplateGenerator
{
    public override string Token => "<<RANDOM_NUMBER>>";

    public override string Apply(string template, string[] arguments)
    {
        return template.ReplaceFirst(
            Token,
            RNG.Between(int.Parse(arguments[0]), int.Parse(arguments[1])).ToString());
    }
}