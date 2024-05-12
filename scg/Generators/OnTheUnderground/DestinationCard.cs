using scg.Generators.OnTheUnderground.Berlin;
using scg.Generators.OnTheUnderground.London;
using scg.Generators.OnTheUnderground.NewYork;
using scg.Generators.OnTheUnderground.Paris;

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

    public DestinationCard(NewYorkLocation location, string region) : this(RouteType.None, region, location.ToString())
    {
    }

    public DestinationCard(NewYorkLocation location, string region, string name) : this(RouteType.None, region, name)
    {

    }
    public DestinationCard(ParisLocation location, string region) : this(RouteType.None, region, location.ToString())
    {
    }

    public DestinationCard(ParisLocation location, string region, string name) : this(RouteType.None, region, name)
    {

    }
}