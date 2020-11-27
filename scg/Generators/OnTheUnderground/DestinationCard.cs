namespace scg.Generators.OnTheUnderground
{
    public class DestinationCard
    {
        public string Name { get; }
        public string Region { get; }
        public LondonLocation Location { get; }
        public RouteType RouteType { get; }

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