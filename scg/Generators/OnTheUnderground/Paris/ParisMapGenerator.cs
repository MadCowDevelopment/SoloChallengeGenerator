using System;
using System.Collections.Generic;
using scg.Framework;
using scg.Utils;
using Svg;

namespace scg.Generators.OnTheUnderground.Paris;

public class ParisMapGenerator : MapGenerator<ParisLine, ParisLocation>
{
    public ParisMapGenerator(GlobalRepository globalRepository) : base(globalRepository)
    {
    }

    protected override void InitializeLandmarks(SvgDocument doc)
    {
        var landmarkLocations = new List<ParisLocation>
        {
        };

        landmarkLocations.Shuffle();

        for (var i = 0; i < landmarkLocations.Count; i++)
        {
            var landmarkIcon = doc.GetElementById<SvgImage>($"Landmark{i + 1}");
            landmarkIcon.X = new SvgUnit(GetCanvasLeft(landmarkLocations[i]));
            landmarkIcon.Y = new SvgUnit(GetCanvasTop(landmarkLocations[i]));
        }
    }

    protected override string SvgFilename { get; } = "Map_Paris.svg";

    private float GetCanvasLeft(ParisLocation landmarkLocation)
    {
        return landmarkLocation switch
        {
            _ => throw new InvalidOperationException($"The location '{landmarkLocation}' is not valid for a landmark.")
        };
    }

    private float GetCanvasTop(ParisLocation landmarkLocation)
    {
        return landmarkLocation switch
        {
            _ => throw new InvalidOperationException($"The location '{landmarkLocation}' is not valid for a landmark.")
        };
    }
}