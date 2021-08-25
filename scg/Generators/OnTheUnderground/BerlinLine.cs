using System.Collections.Generic;

namespace scg.Generators.OnTheUnderground
{
    public class BerlinLine : Line<BerlinLocation>
    {
        public BerlinLine(int id, string name, int value, BerlinLineIcon icon, IEnumerable<BerlinLocation> locations)
            : base(id, name, value, locations)
        {

            Icon = icon;
        }

        public BerlinLineIcon Icon { get; }
    }

    public enum BerlinLineIcon
    {
        None,
        Circle,
        Triangle,
        Square,
    }
}