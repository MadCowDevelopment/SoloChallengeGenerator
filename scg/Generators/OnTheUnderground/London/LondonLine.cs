using System.Collections.Generic;

namespace scg.Generators.OnTheUnderground.London;

public class LondonLine : Line<LondonLocation>
{
    public LondonLine(int id, string name, int value, IEnumerable<LondonLocation> locations)
        : base(id, name, value, locations)
    {
    }
}