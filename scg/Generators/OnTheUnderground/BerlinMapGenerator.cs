using System;
using System.Collections.Generic;
using scg.Framework;
using scg.Utils;
using Svg;
using static scg.Generators.OnTheUnderground.BerlinLocation;

namespace scg.Generators.OnTheUnderground;

public class BerlinMapGenerator : MapGenerator<BerlinLine, BerlinLocation>
{
    public BerlinMapGenerator(GlobalRepository globalRepository) : base(globalRepository)
    {
    }

    protected override void InitializeLandmarks(SvgDocument doc)
    {
        var threePointLocations = new List<BerlinLocation>
        {
            Adlershof, Greifswalderstr, HermannStr, Ostbahnhof, HohenzollernDamm
        };
        threePointLocations.Shuffle();

        var twoPointLocations = new List<BerlinLocation>
        {
            AltTegel, KrummeLanke, Hauptbahnhof, Kurfuerstendamm, RathausSteglitz,
            OsloerStr, Spandau, Westend, Wittenau, Wuhletal
        };
        twoPointLocations.Shuffle();

        var onePointLocations = new List<BerlinLocation>
        {
            Schoenfliess, PaulSternStr, KoellnischeHeide, Koepenick, Grunewald
        };
        onePointLocations.Shuffle();

        var landmarkIndex = 1;
        for (var i = 0; i < 5; i++)
        {
            var threePoint = threePointLocations[i];
            SetLandmarkLocation(doc, landmarkIndex++, threePointLocations[i]);
            SetLandmarkLocation(doc, landmarkIndex++, twoPointLocations[i]);
            SetLandmarkLocation(doc, landmarkIndex++, twoPointLocations[i+5]);
            SetLandmarkLocation(doc, landmarkIndex++, onePointLocations[i]);
        }
    }

    private void SetLandmarkLocation(SvgDocument doc, int landmarkIndex, BerlinLocation location)
    {
        var icon = doc.GetElementById<SvgImage>($"Landmark{landmarkIndex}");
        icon.X = new SvgUnit(GetCanvasLeft(location));
        icon.Y = new SvgUnit(GetCanvasTop(location));
    }

    protected override string SvgFilename { get; } = "Map_Berlin.svg";

    private float GetCanvasLeft(BerlinLocation landmarkLocation)
    {
        return landmarkLocation switch
        {
            Adlershof => 340,
            AltTegel => 124,
            Greifswalderstr => 268,
            Grunewald => 52,
            Hauptbahnhof => 173,
            HermannStr => 244,
            HohenzollernDamm => 100,
            KoellnischeHeide => 293,
            Koepenick => 341,
            Kurfuerstendamm => 149,
            KrummeLanke => 76,
            OsloerStr => 172,
            Ostbahnhof => 244,
            PaulSternStr => 76,
            RathausSteglitz => 148,
            Schoenfliess => 196,
            Spandau => 28,
            Westend => 100,
            Wittenau => 172,
            Wuhletal => 365,
            _ => throw new InvalidOperationException(
                $"The location '{landmarkLocation}' is not valid for a landmark.")
        };
    }

    private float GetCanvasTop(BerlinLocation landmarkLocation)
    {
        return landmarkLocation switch
        {
            Adlershof => 247,
            AltTegel => 53,
            Greifswalderstr => 102,
            Grunewald => 198,
            Hauptbahnhof => 126,
            HermannStr => 223,
            HohenzollernDamm => 198,
            KoellnischeHeide => 222,
            Koepenick => 199,
            Kurfuerstendamm => 174,
            KrummeLanke => 247,
            OsloerStr => 77,
            Ostbahnhof => 150,
            PaulSternStr => 101,
            RathausSteglitz => 247,
            Schoenfliess => 28,
            Spandau => 125,
            Westend => 125,
            Wittenau => 53,
            Wuhletal => 125,
            _ => throw new InvalidOperationException(
                $"The location '{landmarkLocation}' is not valid for a landmark.")
        };
    }
}