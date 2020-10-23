using System.Collections.Generic;

namespace scg.Games.OnTheUnderground.Logic
{
    public class DestinationDeck
    {
        private readonly List<DestinationCard> _destinations;

        public DestinationDeck(List<DestinationCard> destinations)
        {
            _destinations = destinations;
        }
    }
}