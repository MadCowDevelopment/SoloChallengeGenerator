using System.Collections.Generic;

namespace scg.Generators.OnTheUnderground.Paris;

public class ParisLine : Line<ParisLocation>
{
    public ParisLine(int id, string name, int value, IEnumerable<ParisLocation> locations)
        : base(id, name, value, locations)
    {
    }

    public ParisLocation Icon { get; }
}
