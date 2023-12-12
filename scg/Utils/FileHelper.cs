using System;
using System.Diagnostics;
using System.IO;

namespace scg.Utils;

public static class FileHelper
{
    public static void OpenFile(string filename)
    {
        var pi = new ProcessStartInfo(Path.Combine(Environment.CurrentDirectory, filename))
        {
            Arguments = Path.GetFileName(Path.Combine(Environment.CurrentDirectory, filename)),
            UseShellExecute = true,
            WorkingDirectory = Environment.CurrentDirectory,
            Verb = "OPEN"
        };

        Process.Start(pi);
    }
}