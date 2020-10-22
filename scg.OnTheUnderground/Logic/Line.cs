using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Media;

namespace scg.OnTheUnderground.Logic
{
    public class Line
    {
        private string Name { get; }
        private int Value { get; }
        public IEnumerable<LondonLocation> Locations { get; }
        public Color Color { get; }

        public Line(string name, int value, Color color, IEnumerable<LondonLocation> locations)
        {
            Name = name;
            Value = value;
            Color = color;
            Locations = locations.ToImmutableList();
        }
    }
}