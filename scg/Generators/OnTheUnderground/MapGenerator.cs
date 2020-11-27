using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using scg.Framework;
using scg.Utils;
using Svg;
using static scg.Generators.OnTheUnderground.LondonLocation;

namespace scg.Generators.OnTheUnderground
{
    public class MapGenerator
    {
        private readonly GlobalRepository _globalRepository;

        public MapGenerator(GlobalRepository globalRepository)
        {
            _globalRepository = globalRepository;
        }

        public void Generate(LondonLine line1, LondonLine line2)
        {
            var doc = SvgDocument.Open<SvgDocument>(_globalRepository.Open("OnTheUnderground.svg"), null);

            foreach (var svgRectangle in doc.Descendants().OfType<SvgRectangle>())
            {
                svgRectangle.Visibility = "hidden";
            }

            InitializeLandmarks(doc);
            InitializeLine(doc, line1, Color.Gold);
            InitializeLine(doc, line2, Color.DeepPink);

            var bitmap = doc.Draw();
            bitmap.Save("SETUP_IMAGE.png");
        }

        private void InitializeLandmarks(SvgDocument doc)
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

        private void InitializeLine(SvgDocument doc, LondonLine line, Color color)
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

        private SvgRectangle FindTrackRectangle(SvgDocument doc, LondonLocation start, LondonLocation end)
        {
            return GetTrackIdentifiers(start, end).Select(doc.GetElementById<SvgRectangle>)
                .FirstOrDefault(rectangle => rectangle != null && rectangle.Visibility != "visible");
        }

        private IEnumerable<string> GetTrackIdentifiers(LondonLocation start, LondonLocation end)
        {
            yield return $"{start}_{end}_1";
            yield return $"{start}_{end}_2";
            yield return $"{end}_{start}_1";
            yield return $"{end}_{start}_2";
        }

    }
}