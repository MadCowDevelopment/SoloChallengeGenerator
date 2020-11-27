using System;
using System.Collections.Generic;
using System.Linq;
using scg.Framework;

namespace scg.Generators.OnTheUnderground
{
    public class LineSetupGenerator : TemplateGenerator
    {
        private readonly BuildingData _buildingData;
        private readonly GenerationResult _generationResult;
        private readonly MapGenerator _mapGenerator;
        private readonly IReadOnlyCollection<LondonLine> _lines;

        public LineSetupGenerator(BuildingData buildingData, GenerationResult generationResult, MapGenerator mapGenerator)
        {
            _buildingData = buildingData;
            _generationResult = generationResult;
            _mapGenerator = mapGenerator;
            _lines = new LinesFactory().CreateLines();
        }
        public override string Token { get; } = "<<LINE_SETUP>>";

        [STAThread]
        public override string Apply(string template, string[] arguments)
        {
            var lines = _buildingData.GetAndSkipTakenBuildings("LINE", 2).ToList();
            var line1 = _lines.First(p => p.Id == lines[0].Id);
            var line2 = _lines.First(p => p.Id == lines[1].Id);

            _mapGenerator.Generate(line1, line2);
            _generationResult.AddImage(new GeekImage("SETUP_IMAGE", "SETUP_IMAGE.png"));

            var setupText =
                $"Setup the board like the image, with the yellow ({line1.Value}) and pink ({line2.Value}) lines belonging to the Underground. " +
                $"The Underground starts at {line1.Value + line2.Value} points and we start with [b]no[/b] branching tokens. " +
                "The game immediately ends once we overtake the Underground or the destination deck is empty.";

            return template.Replace(Token, setupText);
        }

        private void CreateMap(LondonLine line1, LondonLine line2)
        {
            
        }
    }
}
