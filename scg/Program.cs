using System.Threading.Tasks;
using CommandLine;
using scg.App.Generator;
using scg.App.Options;
using scg.App.Scores;
using scg.Utils;

CultureInitializer.Initialize();

return Parser.Default.ParseArguments<GenerateOptions, ScoreOptions, ConfigOptions>(args)
    .MapResult(
        (GenerateOptions opts) => Generator.Generate(opts),
        (ScoreOptions opts) => Scorer.Add(opts),
        (ConfigOptions opts) => Config.Run(opts),
        errs => Task.FromResult(1)).Result;