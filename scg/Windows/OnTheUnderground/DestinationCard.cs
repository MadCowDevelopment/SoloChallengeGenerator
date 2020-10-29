namespace scg.Games.OnTheUnderground.Logic
{
    public class DestinationCard
    {
        private string Name { get; }
        private string Region { get; }
        private LondonLocation Location { get; }
        private RouteType RouteType { get; }

        public DestinationCard(LondonLocation location, RouteType routeType, string region)
            : this(location, routeType, region, location.ToString()) { }

        public DestinationCard(LondonLocation location, RouteType routeType, string region, string name)
        {
            Name = name;
            Region = region;
            Location = location;
            RouteType = routeType;
        }
    }
}