using System.Collections.Generic;

namespace scg.Generators.OnTheUnderground
{
    public class Line<T> : Line
    {
        public Line(int id, string name, int value, IEnumerable<T> locations) : base(id, name, value)
        {
            Locations = locations;
        }

        public IEnumerable<T> Locations { get; }
    }

    public class Line
    {
        public Line(int id, string name, int value)
        {
            Id = id;
            Name = name;
            Value = value;
        }

        public int Id { get; }
        public string Name { get; }
        public int Value { get; }
    }

    public class LondonLine : Line<LondonLocation>
    {
        public LondonLine(int id, string name, int value, IEnumerable<LondonLocation> locations)
            : base(id, name, value, locations)
        {
        }
    }
}
