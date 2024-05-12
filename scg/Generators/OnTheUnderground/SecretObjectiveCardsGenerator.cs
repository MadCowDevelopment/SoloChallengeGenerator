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
        "B2 Pereire  |  C2 Gare De L'Est  |  C4 Montparnasse - Bienvenue",
        "A3 Charles De Gaulle - Etoile  |  C2 Gare De L'Est  |  D3 Nation",
        "B2 Saint-Lazare  |  C1 Gare Du Nord  |  D3 Gare D'Austerlitz",
        "B2 Saint-Lazare  |  B3 Invalides  |  D3 Gare De Lyon",
        "A3 Champ De Mars - Tour Eiffel  |  B2 Saint-Lazare  |  C3 Chatelet",
        "B3 Sevres - Babylone  |  C1 Gare Du Nord  |  C3 Chatelet",
        "A3 Charles De Gaulle - Etoile  |  C3 Saint-Michel Notre-Dame  |  D2 Republique",
        "C2 Opera  |  C4 Denfert-Rochereau  |  D3 Nation",
        "A3 La Muette  |  C2 Opera  |  C4 Montparnasse - Bienvenue",
        "C4 Montparnasse - Bienvenue  |  D2 Republique  |  D3 Gare De Lyon",
        "B1 Porte De Clichy  |  C3 Chatelet  |  D2 Republique"
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
        builder.AppendLine("Secret Objectives:");
        builder.Append("[c]");
        for(int i=0; i< 3; i++)
        {
            builder.AppendLine(_secretObjectives[i]);
        }

        builder.Append("[/c]");
        builder.AppendLine();

        return builder.ToString();
    }
}
