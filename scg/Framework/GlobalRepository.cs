using System;

namespace scg.Framework;

public class GlobalRepository : RepositoryBase
{
    public GlobalRepository() : base("scg.")
    {
    }

    public string[] ReadAllLines(string filename)
    {
        return ReadEmbeddedResource(filename).Split(Environment.NewLine);
    }
}