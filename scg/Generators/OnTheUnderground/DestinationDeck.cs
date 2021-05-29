using System.Collections.Generic;
using System.Linq;
using scg.Utils;

namespace scg.Generators.OnTheUnderground
{
    public class DestinationDeck
    {
        public string Id { get; }

        public DestinationDeck(string id, IEnumerable<DestinationCard> destinations)
        {
            Id = id;
            Destinations = destinations.ToList();
            Destinations.Shuffle();
        }

        public List<DestinationCard> Destinations { get; }
    }
}
