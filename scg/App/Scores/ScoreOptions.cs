using CommandLine;

namespace scg.App.Scores
{
    [Verb("score", HelpText = "Modifies previous challenge scores.")]
    public class ScoreOptions
    {
        [Value(0, MetaName = "GameName", HelpText = "The identifier of the game. E.g. GlassRoad", Required = true)]
        public string Game { get; set; }

        [Value(1, MetaName = "Operation", HelpText = "Supported operations: add, remove, list", Required = true)]
        public string Operation { get; set; }

        [Option('s', "score", HelpText = "The highest score of the challenge.")]
        public double? Score { get; set; }

        [Option('t', "thread", HelpText = "The thread ID of the challenge.")]
        public int? Thread { get; set; }

        [Option('u', "user", HelpText = "The BGG user name of the user with the highest score.")]
        public string User { get; set; }
    }
}