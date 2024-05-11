using System;
using System.Collections.Generic;
using System.Linq;
using scg.Framework;
using scg.Generators.OnTheUnderground.Berlin;
using scg.Generators.OnTheUnderground.London;
using scg.Generators.OnTheUnderground.NewYork;
using scg.Generators.OnTheUnderground.Paris;
using scg.Utils;

namespace scg.Generators.OnTheUnderground;

public class LineSetupGenerator : TemplateGenerator
{
    private readonly BuildingData _buildingData;
    private readonly GenerationResult _generationResult;
    private readonly LondonMapGenerator _londonMapGenerator;
    private readonly BerlinMapGenerator _berlinMapGenerator;
    private readonly NewYorkMapGenerator _newYorkMapGenerator;
    private readonly ParisMapGenerator _parisMapGenerator;
    private readonly GameOptions _gameOptions;

    public LineSetupGenerator(
        BuildingData buildingData, 
        GenerationResult generationResult,
        LondonMapGenerator londonMapGenerator, 
        BerlinMapGenerator berlinMapGenerator,
        NewYorkMapGenerator newYorkMapGenerator,
        ParisMapGenerator parisMapGenerator,
        GameOptions gameOptions)
    {
        _buildingData = buildingData;
        _generationResult = generationResult;
        _londonMapGenerator = londonMapGenerator;
        _berlinMapGenerator = berlinMapGenerator;
        _newYorkMapGenerator = newYorkMapGenerator;
        _parisMapGenerator = parisMapGenerator;
        _gameOptions = gameOptions;
    }

    public override string Token { get; } = "<<LINE_SETUP>>";

    [STAThread]
    public override string Apply(string template, string[] arguments)
    {
        var lines = _buildingData.GetAndSkipTakenBuildings("LINE", 2).ToList();

        var (line1, line2) = GenerateImage(lines);
        var targetScore = CalculateTargetScore(line1, line2);

        _generationResult.AddImage(new GeekImage("SETUP_IMAGE", "SETUP_IMAGE.png"));

        var setupText =
            $"Setup the board like the image, with the yellow ({line1.Value}) and pink ({line2.Value}) lines belonging to the Underground. " +
            $"The Underground starts at {targetScore} points and we start with [b]one[/b] branching tokens. " +
            "The game immediately ends once we overtake the Underground or the destination deck is empty.";

        return template.ReplaceFirst(Token, setupText);
    }

    private int CalculateTargetScore(Line line1, Line line2)
    {
        var baseScore = line1.Value + line2.Value;
        var expertScore = baseScore + 20;

        if (line1 is BerlinLine berlinLine1 && line2 is BerlinLine berlinLine2)
        {
            if (berlinLine1.Icon != BerlinLineIcon.None && berlinLine1.Icon == berlinLine2.Icon)
            {
                return expertScore + 30;
            }
        }

        return expertScore;
    }

    private (Line line1, Line line2) GenerateImage(List<Building> lines)
    {
        var newYorkLines = NewYorkLinesFactory.Create();
        var line1 = newYorkLines.First(p => p.Id == 9);
        var line2 = newYorkLines.First(p => p.Id == 10);

        _newYorkMapGenerator.Generate(line1, line2);
        return (line1, line2);

        //var map = _gameOptions.Options["Map"];
        //if (map == "London")
        //{
        //    var londonLines = LondonLinesFactory.Create();
        //    var line1 = londonLines.First(p => p.Id == lines[0].Id);
        //    var line2 = londonLines.First(p => p.Id == lines[1].Id);

        //    _londonMapGenerator.Generate(line1, line2);
        //    return (line1, line2);
        //}

        //if (_gameOptions.Options["Map"] == "Berlin")
        //{
        //    var berlinLines = BerlinLinesFactory.Create();
        //    var line1 = berlinLines.First(p => p.Id == lines[0].Id);
        //    var line2 = berlinLines.First(p => p.Id == lines[1].Id);

        //    _berlinMapGenerator.Generate(line1, line2);
        //    return (line1, line2);
        //}

        //if (_gameOptions.Options["Map"] == "NewYork")
        //{
        //    var newYorkLines = NewYorkLinesFactory.Create();
        //    var line1 = newYorkLines.First(p => p.Id == lines[0].Id);
        //    var line2 = newYorkLines.First(p => p.Id == lines[1].Id);

        //    _newYorkMapGenerator.Generate(line1, line2);
        //    return (line1, line2);
        //}

        //if (_gameOptions.Options["Map"] == "Paris")
        //{
        //    var parisLines = ParisLinesFactory.Create();
        //    var line1 = parisLines.First(p => p.Id == lines[0].Id);
        //    var line2 = parisLines.First(p => p.Id == lines[1].Id);

        //    _parisMapGenerator.Generate(line1, line2);
        //    return (line1, line2);
        //}

        //throw new InvalidOperationException($"Map '{map}' is not supported.");
    }
}