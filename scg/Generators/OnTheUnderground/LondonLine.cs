using System.Collections.Generic;

namespace scg.Generators.OnTheUnderground;

public class LondonLine : Line<LondonLocation>
{
    public LondonLine(int id, string name, int value, IEnumerable<LondonLocation> locations)
        : base(id, name, value, locations)
    {
    }
}