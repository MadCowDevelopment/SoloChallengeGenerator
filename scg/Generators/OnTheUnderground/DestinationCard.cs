namespace scg.Generators.OnTheUnderground;

public class DestinationCard
{
    public string Name { get; }
    public string Region { get; }
    public RouteType RouteType { get; }

    private DestinationCard(RouteType routeType, string region, string name)
    {
        Name = name;
        Region = region;
        RouteType = routeType;
    }

    public DestinationCard(LondonLocation location, RouteType routeType, string region) : this(routeType, region, location.ToString())
    {
    }

    public DestinationCard(LondonLocation location, RouteType routeType, string region, string name) : this(routeType, region, name)
    {
    }

    public DestinationCard(BerlinLocation location, RouteType routeType, string region) : this(routeType, region, location.ToString())
    {
    }

    public DestinationCard(BerlinLocation location, RouteType routeType, string region, string name) : this(routeType, region, name)
    {
    }
}