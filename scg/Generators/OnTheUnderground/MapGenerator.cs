using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using scg.Framework;
using Svg;

namespace scg.Generators.OnTheUnderground;

public abstract class MapGenerator<TLine, TLocation> where TLine : Line<TLocation>
{
    protected GlobalRepository GlobalRepository { get; }

    public MapGenerator(GlobalRepository globalRepository)
    {
        GlobalRepository = globalRepository;
    }

    public void Generate(TLine line1, TLine line2)
    {
        var doc = SvgDocument.Open<SvgDocument>(GlobalRepository.Open(SvgFilename), null);

        foreach (var svgRectangle in doc.Descendants().OfType<SvgRectangle>())
        {
            svgRectangle.Visibility = "hidden";
        }

        InitializeLandmarks(doc, line1, line2);
        InitializeLine(doc, line1, Color.Gold);
        InitializeLine(doc, line2, Color.DeepPink);

        var bitmap = doc.Draw();
        bitmap.Save("SETUP_IMAGE.png");
    }

    protected abstract void InitializeLandmarks(SvgDocument doc, TLine line1, TLine line2);

    protected abstract string SvgFilename { get; }


    private void InitializeLine(SvgDocument doc, TLine line, Color color)
    {
        for (var i = 0; i < line.Locations.Count() - 1; i++)
        {
            var start = line.Locations.ElementAt(i);
            var end = line.Locations.ElementAt(i + 1);
            var track = FindTrackRectangle(doc, start, end);
            SetTrack(color, track);
        }
    }

    private static void SetTrack(Color color, SvgRectangle track)
    {
        if (track == null) return;
        track.Visibility = "visible";
        track.Fill = new SvgColourServer(color);
    }

    private SvgRectangle FindTrackRectangle(SvgDocument doc, TLocation start, TLocation end)
    {
        return GetTrackIdentifiers(start, end).Select(doc.GetElementById<SvgRectangle>)
            .FirstOrDefault(rectangle => rectangle != null && rectangle.Visibility != "visible");
    }

    private IEnumerable<string> GetTrackIdentifiers(TLocation start, TLocation end)
    {
        yield return $"{start}_{end}_1";
        yield return $"{start}_{end}_2";
        yield return $"{end}_{start}_1";
        yield return $"{end}_{start}_2";
    }
}