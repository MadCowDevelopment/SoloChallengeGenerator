using System.Collections.Generic;
using System.Collections.Immutable;

namespace scg.Logic
{
    public class Line
    {
        private string Name { get; }
        private int Value { get; }
        private IReadOnlyCollection<LondonLocation> Locations { get; }

        public Line(string name, int value, IEnumerable<LondonLocation> locations)
        {
            Name = name;
            Value = value;
            Locations = locations.ToImmutableList();
        }
    }
}