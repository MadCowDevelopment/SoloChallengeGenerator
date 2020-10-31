using System.Threading.Tasks;
using CommandLine;
using scg.App;
using scg.Utils;

namespace scg
{
    static class Program
    {
        static Task<int> Main(string[] args)
        {
            CultureInitializer.Initialize();

            return Parser.Default.ParseArguments<GenerateOptions>(args)
                .MapResult(
                    (GenerateOptions opts) => Generator.Generate(opts),
                    errs => Task.FromResult(1));
        }
    }
}