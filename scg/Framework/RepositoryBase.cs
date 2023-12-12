using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace scg.Framework;

public abstract class RepositoryBase
{
    private readonly string _resourcePath;

    protected RepositoryBase(string resourcePath)
    {
        _resourcePath = resourcePath;
    }

    protected string ReadEmbeddedResource(string filename)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream($"{_resourcePath}{filename}");
        if (stream == null) return null;
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    public Stream Open(string filename)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var stream = assembly.GetManifestResourceStream($"{_resourcePath}{filename}");
        return stream;
    }

    public IEnumerable<string> GetFiles(string path, string endsWith)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return assembly.GetManifestResourceNames()
            .Where(str => str.StartsWith($"{_resourcePath}{path}") && str.EndsWith(endsWith))
            .Select(p => p.Replace(_resourcePath, ""));
    }
}