using System.Collections.Generic;
using System.Text;
using scg.Framework;
using scg.Utils;

namespace scg.Generators.OnTheUnderground;

public class SecretObjectiveCardsGenerator : TemplateGenerator
{
    private GameOptions _gameOptions;
    private string _map;
    private List<string> _secretObjectives = new List<string>
    {
        "(5 pts) B2 Pereire  |  C2 Gare De L'Est  |  C4 Montparnasse - Bienvenue",
        "(5 pts) A3 Charles De Gaulle - Etoile  |  C2 Gare De L'Est  |  D3 Nation",
        "(3 pts) B2 Saint-Lazare  |  C1 Gare Du Nord  |  D3 Gare D'Austerlitz",
        "(3 pts) B2 Saint-Lazare  |  B3 Invalides  |  D3 Gare De Lyon",
        "(3 pts) A3 Champ De Mars - Tour Eiffel  |  B2 Saint-Lazare  |  C3 Chatelet",
        "(3 pts) B3 Sevres - Babylone  |  C1 Gare Du Nord  |  C3 Chatelet",
        "(5 pts) A3 Charles De Gaulle - Etoile  |  C3 Saint-Michel Notre-Dame  |  D2 Republique",
        "(5 pts) C2 Opera  |  C4 Denfert-Rochereau  |  D3 Nation",
        "(5 pts) A3 La Muette  |  C2 Opera  |  C4 Montparnasse - Bienvenue",
        "(5 pts) C4 Montparnasse - Bienvenue  |  D2 Republique  |  D3 Gare De Lyon",
        "(5 pts) B1 Porte De Clichy  |  C3 Chatelet  |  D2 Republique"
    };

    public SecretObjectiveCardsGenerator(GameOptions gameOptions)
    {
        _gameOptions = gameOptions;
        _secretObjectives.Shuffle();
    }

    public override string Token { get; } = "<<SECRET_OBJECTIVE_CARDS>>";

    private string Map => _map ??= _gameOptions.Options["Map"];

    public override string Apply(string template, string[] arguments)
    {
        var secretObjectiveText = Map == "Paris" ? CreateSecretObjectiveText() : string.Empty;
        return template.Replace(Token, secretObjectiveText);
    }

    private string CreateSecretObjectiveText()
    {
        var builder = new StringBuilder();
        builder.AppendLine();
        builder.AppendLine("[b][color=#1e00ff]Paris:[/color][/b]");
        builder.AppendLine("Choose an unused line and place Track tokens just after each of the following positions on the score track: 10, 25, 40, 60 and 80.");
        builder.AppendLine("If you collect a set of five different Landmark tiles, then instead of the standard scoring, score 7 points. " +
            "Then compare your score to the first Track token on the score track (i.e. the one next to the lowest number): " +
            "If your score is lower, score 3 points as a reward for collecting Landmark tiles quickly! " +
            "In any case, remove the first Track token from the score track.");
        builder.AppendLine();
        builder.AppendLine("[b][color=#1e00ff]Secret Objectives:[/color][/b]");
        builder.Append("[c]");
        for(int i=0; i < 2; i++)
        {
            builder.AppendLine(_secretObjectives[i]);
        }

        builder.Append("[/c]");
        builder.AppendLine();

        return builder.ToString();
    }
}
