using System.Collections.Generic;

namespace scg.Generators.OnTheUnderground.NewYork;

public class NewYorkLine : Line<NewYorkLocation>
{
    public NewYorkLine(int id, string name, int value, NewYorkLineIcon icon, IEnumerable<NewYorkLocation> locations)
        : base(id, name, value, locations)
    {

        Icon = icon;
    }

    public NewYorkLineIcon Icon { get; }
}
