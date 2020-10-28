using System.Threading.Tasks;
using CommandLine;
using scg.App;

namespace scg
{
    class Program
    {
        static Task<int> Main(string[] args)
        {
            return Parser.Default.ParseArguments<GenerateOptions>(args)
                .MapResult(
                    (GenerateOptions opts) => Generator.Generate(opts),
                    errs => Task.FromResult(1));
        }
    }
}