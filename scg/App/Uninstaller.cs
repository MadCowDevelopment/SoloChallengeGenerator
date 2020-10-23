using System.Threading.Tasks;
using CommandLine;

namespace scg.App
{
    public class Uninstaller
    {
        public static Task<int> Run(UninstallOptions opts)
        {
            return Task.FromResult(0);
        }
    }

    [Verb("uninstall", HelpText = "Uninstall an existing game plugin.")]
    public class UninstallOptions
    {
        //commit options here
    }
}
