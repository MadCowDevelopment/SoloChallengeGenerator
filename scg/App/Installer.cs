using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;
using scg.Services;

namespace scg.App
{
    public class Installer
    {
        public static async Task<int> Run(InstallOptions opts)
        {
            var nuget = new NugetService();
            var packages = await nuget.Search();
            await nuget.Download(packages.First().PackageId, packages.First().PackageVersion);
            return 0;
        }
    }

    [Verb("install", HelpText = "Install a new game plugin.")]
    public class InstallOptions
    {
        [Option('r', "read", Required = true, HelpText = "Input files to be processed.")]
        public IEnumerable<string> InputFiles { get; set; }

        // Omitting long name, defaults to name of property, ie "--verbose"
        [Option(
            Default = false,
            HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

        [Option("stdin",
            Default = false,
            HelpText = "Read from stdin")]
        public bool stdin { get; set; }

        [Value(0, MetaName = "offset", HelpText = "File offset.")]
        public long? Offset { get; set; }
    }
}
