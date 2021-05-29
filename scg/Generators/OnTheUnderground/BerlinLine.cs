using System.Collections.Generic;

namespace scg.Generators.OnTheUnderground
{
    public class BerlinLine : Line<BerlinLocation>
    {
        public BerlinLine(int id, string name, int value, IEnumerable<BerlinLocation> locations)
            : base(id, name, value, locations)
        {
        }
    }
}
