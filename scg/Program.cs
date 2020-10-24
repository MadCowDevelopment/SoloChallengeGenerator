using System.Threading.Tasks;
using CommandLine;
using scg.App;

namespace scg
{
    class Program
    {
        static Task<int> Main(string[] args)
        {
            return Parser.Default.ParseArguments<GenerateOptions, InstallOptions, UninstallOptions>(args)
                .MapResult(
                    (GenerateOptions opts) => Generator.Generate(opts),
                    (InstallOptions opts) => Installer.Run(opts),
                    (UninstallOptions opts) => Uninstaller.Run(opts),
                    errs => Task.FromResult(1));
        }
    }
}