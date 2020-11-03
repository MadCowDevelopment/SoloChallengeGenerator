using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows.Media;

namespace scg.Windows.OnTheUnderground
{
    public class LondonLine
    {
        public int Id { get; }
        private string Name { get; }
        public int Value { get; }
        public IEnumerable<LondonLocation> Locations { get; }
        public Color Color { get; }
        public string ColorName { get; }

        public LondonLine(int id, string name, int value, Color color, string colorName, IEnumerable<LondonLocation> locations)
        {
            Id = id;
            Name = name;
            Value = value;
            Color = color;
            ColorName = colorName;
            Locations = locations.ToImmutableList();
        }
    }
}