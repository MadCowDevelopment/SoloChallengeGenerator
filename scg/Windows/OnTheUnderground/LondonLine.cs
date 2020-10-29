using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Media;

namespace scg.Games.OnTheUnderground.Logic
{
    public class LondonLine
    {
        private string Name { get; }
        private int Value { get; }
        public IEnumerable<LondonLocation> Locations { get; }
        public Color Color { get; }

        public LondonLine(string name, int value, Color color, IEnumerable<LondonLocation> locations)
        {
            Name = name;
            Value = value;
            Color = color;
            Locations = locations.ToImmutableList();
        }
    }
}