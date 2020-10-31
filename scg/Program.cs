using System.Threading.Tasks;
using CommandLine;
using scg.App;
using scg.App.Generator;
using scg.App.Scores;
using scg.Utils;

namespace scg
{
    static class Program
    {
        static Task<int> Main(string[] args)
        {
            CultureInitializer.Initialize();

            return Parser.Default.ParseArguments<GenerateOptions, ScoreOptions>(args)
                .MapResult(
                    (GenerateOptions opts) => Generator.Generate(opts),
                    (ScoreOptions opts) => Scorer.Add(opts),
                    errs => Task.FromResult(1));
        }
    }
}