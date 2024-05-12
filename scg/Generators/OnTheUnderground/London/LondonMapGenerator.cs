using System;
using System.Collections.Generic;
using scg.Framework;
using scg.Utils;
using Svg;
using static scg.Generators.OnTheUnderground.London.LondonLocation;

namespace scg.Generators.OnTheUnderground.London;

public class LondonMapGenerator : MapGenerator<LondonLine, LondonLocation>
{
    public LondonMapGenerator(GlobalRepository globalRepository) : base(globalRepository)
    {
    }

    protected override void InitializeLandmarks(SvgDocument doc, LondonLine line1, LondonLine line2)
    {
        var landmarkLocations = new List<LondonLocation>
        {
            KingsCrossStPancras, BakerStreet, NottingHillGate, Hammersmith, Victoria, CharingCross, ElephantAndCastle, Aldgate
        };

        landmarkLocations.Shuffle();

        for (var i = 0; i < landmarkLocations.Count; i++)
        {
            var landmarkIcon = doc.GetElementById<SvgImage>($"Landmark{i + 1}");
            landmarkIcon.X = new SvgUnit(GetCanvasLeft(landmarkLocations[i]));
            landmarkIcon.Y = new SvgUnit(GetCanvasTop(landmarkLocations[i]));
        }
    }

    protected override string SvgFilename { get; } = "Map_London.svg";

    private float GetCanvasLeft(LondonLocation landmarkLocation)
    {
        return landmarkLocation switch
        {
            KingsCrossStPancras => 258,
            BakerStreet => 189,
            NottingHillGate => 143,
            Hammersmith => 119,
            Victoria => 189,
            CharingCross => 235,
            ElephantAndCastle => 235,
            Aldgate => 305,
            _ => throw new InvalidOperationException($"The location '{landmarkLocation}' is not valid for a landmark.")
        };
    }

    private float GetCanvasTop(LondonLocation landmarkLocation)
    {
        return landmarkLocation switch
        {
            KingsCrossStPancras => 128,
            BakerStreet => 127,
            NottingHillGate => 150,
            Hammersmith => 197,
            Victoria => 197,
            CharingCross => 197,
            ElephantAndCastle => 244,
            Aldgate => 174,
            _ => throw new InvalidOperationException($"The location '{landmarkLocation}' is not valid for a landmark.")
        };
    }
}