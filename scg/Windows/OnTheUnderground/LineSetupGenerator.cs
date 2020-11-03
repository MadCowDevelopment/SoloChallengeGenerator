using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using scg.Framework;
using scg.Generators;
using scg.Windows.Utils;

namespace scg.Windows.OnTheUnderground
{
    public class LineSetupGenerator : TemplateGenerator
    {
        private readonly BuildingData _buildingData;
        private readonly GenerationResult _generationResult;
        private readonly IReadOnlyCollection<LondonLine> _lines;

        public LineSetupGenerator(BuildingData buildingData, GenerationResult generationResult)
        {
            _buildingData = buildingData;
            _generationResult = generationResult;
            _lines = new LinesFactory().CreateLines();
        }
        public override string Token { get; } = "<<LINE_SETUP>>";

        [STAThread]
        public override string Apply(string template, string[] arguments)
        {
            var lines = _buildingData.GetAndSkipTakenBuildings("LINE", 2).ToList();
            var line1 = _lines.First(p => p.Id == lines[0].Id);
            var line2 = _lines.First(p => p.Id == lines[1].Id);

            var map = CreateMap(line1, line2);
            var filename = "SETUP_IMAGE.png";
            UserControlExporter.SaveAsImage(map, filename);
            _generationResult.AddImage(new GeekImage("SETUP_IMAGE", "SETUP_IMAGE.png"));

            var setupText =
                $"Setup the board like the image, with the {line1.ColorName} ({line1.Value}) and {line2.ColorName} ({line2.Value}) lines belonging to the Underground. " +
                $"The Underground starts at {line1.Value + line2.Value} points and we start with [b]no[/b] branching tokens. " +
                "The game immediately ends once we overtake the Underground or the destination deck is empty.";

            return template.Replace(Token, setupText);
        }

        private UserControl CreateMap(LondonLine line1, LondonLine line2)
        {
            var map = new LondonMap();
            map.InitializeLine(line1);
            map.InitializeLine(line2);
            map.Measure(new Size(1600, 1078));
            map.Arrange(new Rect(0, 0, map.DesiredSize.Width, map.DesiredSize.Height));
            return map;
        }
    }
}
