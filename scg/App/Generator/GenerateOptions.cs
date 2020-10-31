using CommandLine;

namespace scg.App.Generator
{
    [Verb("generate", isDefault: true, HelpText = "Generate a new challenge post.")]
    public class GenerateOptions
    {
        [Value(0, MetaName = "GameName", HelpText = "The identifier of the game. E.g. GlassRoad", Required = true)]
        public string Game { get; set; }

        [Option('p', "publish", Default = false, HelpText = "Automatically upload the generated post to BoardGameGeek (requires BGG account).")]
        public bool Publish { get; set; }

        [Option('u', "user", HelpText = "The BGG user name that will be used for uploading the generated post.")]
        public string User { get; set; }
    }
}