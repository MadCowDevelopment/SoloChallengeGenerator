using CommandLine;

namespace scg.App.Options
{
    [Verb("config", HelpText = "Configures the application settings.")]
    public class ConfigOptions
    {
        [Value(0, MetaName = "Operation", HelpText = "Supported operations: get, set", Required = true)]
        public string Operation { get; set; }

        [Value(1, MetaName = "Identifier", HelpText = "The identifier of the setting that should be set.", Required = true)]
        public string Identifier { get; set; }

        [Value(2, MetaName = "Value", HelpText = "The value of the setting.", Required = false)]
        public string Value { get; set; }
    }
}