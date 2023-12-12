namespace scg.Generators.Cartographers;

public static class ShapeHelper
{
    public static string Print(string shape, bool drawRuins)
    {
        shape = shape.Replace(" ", "[microbadge=12865]");
        shape = drawRuins ? shape.Replace("X", "[microbadge=44987]") : shape.Replace("X", "[microbadge=23792]");
        shape = shape.Replace("O", "[microbadge=2301]");
        shape = shape.Replace("G", "[microbadge=47]");
        shape = shape.Replace("U", "[microbadge=10790]");
        shape = shape.Replace("D", "[microbadge=10788]");
        shape = shape.Replace("L", "[microbadge=10791]");
        shape = shape.Replace("R", "[microbadge=10792]");
        shape = shape.Replace("S", "[microbadge=35694]");
        shape = shape.Replace("B", "[microbadge=28873]");
        return shape;
    }
}