using scg.Framework;
using Svg;

namespace scg.Generators.OnTheUnderground.NewYork;

public class NewYorkMapGenerator : MapGenerator<NewYorkLine, NewYorkLocation>
{
    public NewYorkMapGenerator(GlobalRepository globalRepository) : base(globalRepository)
    {
    }

    protected override void InitializeLandmarks(SvgDocument doc, NewYorkLine line1, NewYorkLine line2)
    {
    }

    protected override string SvgFilename { get; } = "Map_NewYork.svg";
}