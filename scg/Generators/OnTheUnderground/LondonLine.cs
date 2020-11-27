using System.Collections.Generic;
using System.Collections.Immutable;

namespace scg.Generators.OnTheUnderground
{
    public class LondonLine
    {
        public int Id { get; }
        private string Name { get; }
        public int Value { get; }
        public IEnumerable<LondonLocation> Locations { get; }

        public LondonLine(int id, string name, int value, IEnumerable<LondonLocation> locations)
        {
            Id = id;
            Name = name;
            Value = value;
            Locations = locations.ToImmutableList();
        }
    }
}