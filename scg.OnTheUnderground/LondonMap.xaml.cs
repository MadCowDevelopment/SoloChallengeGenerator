using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using scg.OnTheUnderground.Logic;
using static scg.OnTheUnderground.Logic.LondonLocation;

namespace scg.OnTheUnderground
{
    /// <summary>
    /// Interaction logic for LondonMap.xaml
    /// </summary>
    public partial class LondonMap
    {
        public LondonMap()
        {
            InitializeComponent();
            InitializeLandmarks();

            var lines = new LinesFactory().CreateLines();
            InitializeLine(lines.ElementAt(9));
            InitializeLine(lines.ElementAt(10));
        }

        public void InitializeLine(LondonLine line)
        {
            for (var i = 0; i < line.Locations.Count() - 1; i++)
            {
                var start = line.Locations.ElementAt(i);
                var end = line.Locations.ElementAt(i + 1);
                var track = FindTrackRectangle(start, end);
                SetTrack(line.Color, track);
            }
        }

        private static void SetTrack(Color color, Rectangle track)
        {
            if (track == null) return;
            track.Visibility = Visibility.Visible;
            track.Fill = new SolidColorBrush(color);
        }

        private Rectangle FindTrackRectangle(LondonLocation start, LondonLocation end)
        {
            return GetTrackIdentifiers(start, end).Select(trackIdentifier => FindName(trackIdentifier) as Rectangle)
                .FirstOrDefault(rectangle =>rectangle != null && rectangle.Visibility != Visibility.Visible);
        }

        private IEnumerable<string> GetTrackIdentifiers(LondonLocation start, LondonLocation end)
        {
            yield return $"{start}_{end}_1";
            yield return $"{start}_{end}_2";
            yield return $"{end}_{start}_1";
            yield return $"{end}_{start}_2";
        }

        private void InitializeLandmarks()
        {
            var landmarkLocations = new List<LondonLocation>
            {
                KingsCrossStPancras, BakerStreet, NottingHillGate, Hammersmith, Victoria, CharingCross, ElephantAndCastle, Aldgate
            };

            landmarkLocations.Shuffle();

            for (var i = 0; i < landmarkLocations.Count; i++)
            {
                var landmarkIcon = FindName($"Landmark{i + 1}") as UIElement;
                Canvas.SetLeft(landmarkIcon, GetCanvasLeft(landmarkLocations[i]));
                Canvas.SetTop(landmarkIcon, GetCanvasTop(landmarkLocations[i]));
            }
        }

        private double GetCanvasLeft(LondonLocation landmarkLocation)
        {
            return landmarkLocation switch
            {
                KingsCrossStPancras => 997,
                BakerStreet => 731,
                NottingHillGate => 552,
                Hammersmith => 459,
                Victoria => 730,
                CharingCross => 908,
                ElephantAndCastle => 907,
                Aldgate => 1177,
                _ => throw new InvalidOperationException($"The location '{landmarkLocation}' is not valid for a landmark.")
            };
        }

        private double GetCanvasTop(LondonLocation landmarkLocation)
        {
            return landmarkLocation switch
            {
                KingsCrossStPancras => 447,
                BakerStreet => 446,
                NottingHillGate => 534,
                Hammersmith => 714,
                Victoria => 714,
                CharingCross => 714,
                ElephantAndCastle => 897,
                Aldgate => 628,
                _ => throw new InvalidOperationException($"The location '{landmarkLocation}' is not valid for a landmark.")
            };
        }
    }
}
