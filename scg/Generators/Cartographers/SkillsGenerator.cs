using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Framework;

namespace scg.Generators.Cartographers
{
    internal class SkillsGenerator : TemplateGenerator
    {
        private static readonly string NL = Environment.NewLine;

        private readonly BuildingData _buildingData;

        private Dictionary<int, string> _skillDescriptions;
        private Dictionary<int, string> _skillNumbers;

        public SkillsGenerator(BuildingData buildingData)
        {
            _buildingData = buildingData;


        }

        public override string Token { get; } = "<<SKILL_CARDS>>";

        public override string Apply(string template, string[] arguments)
        {
            var set = arguments[0];
            InitializeSkills(set);

            var skills = _buildingData.GetAndSkipTakenBuildings("Skill", 3).ToList();

            var builder = new StringBuilder();
            builder.Append("[size=11]");
            builder.AppendLine($"A) {_skillNumbers[skills[0].Id]} {skills[0].ToPostFormatWithoutDuplicateTranslations()}");
            builder.AppendLine(S(_skillDescriptions[skills[0].Id]));
            builder.AppendLine($"B) {_skillNumbers[skills[1].Id]} {skills[1].ToPostFormatWithoutDuplicateTranslations()}");
            builder.AppendLine(S(_skillDescriptions[skills[1].Id]));
            builder.AppendLine($"C) {_skillNumbers[skills[2].Id]} {skills[2].ToPostFormatWithoutDuplicateTranslations()}");
            builder.AppendLine(S(_skillDescriptions[skills[2].Id]));
            builder.Append("[/size]");

            return template.Replace(Token, builder.ToString());
        }

        private string S(string description)
        {
            if (!description.Contains("$$"))
            {
                return description;
            }

            var startIndexOfShape = description.IndexOf("$$");
            var endIndexOfShape = description.IndexOf("$$", startIndexOfShape + 1);

            var beforeShape = description.Substring(0, startIndexOfShape);
            var shape = description.Substring(startIndexOfShape + 2, endIndexOfShape - startIndexOfShape - 2);
            var afterShape = description.Substring(endIndexOfShape + 2);

            var result = new StringBuilder();
            result.Append(beforeShape);
            result.Append(ShapeHelper.Print(shape, false));
            result.Append(afterShape);

            return result.ToString();
        }

        private void InitializeSkills(string set)
        {
            if (set == "Base")
            {
                _skillDescriptions = new Dictionary<int, string>
                {
                    { 38, "Cost: [b]1[/b] coin - During the Draw phase, draw an additional 2x1 shape adjacent to a monster space. Fill it with an available terrain type."},
                    { 39, "Cost: [b]2[/b] coins - During the Draw phase, if an ambush card is revealed, the shape drawn on your map sheet is a 2x1 shape instead of the depicted shape." },
                    { 40, "Cost: [b]3[/b] coins - During the Draw phase, if an ambush card is not revealed, draw the chosen shape a second time. Fill it with the same terrain type." },
                    { 41, "Cost: [b]0[/b] coins - During the Draw phase, fill the chosen shape with village terrain instead of an available type." },
                    { 42, "Cost: [b]1[/b] coin - At any time, draw a 1x1 square and fill it with both farm terrain and village terrain types." },
                    { 43, "Cost: [b]0[/b] coins - During the Draw phase, draw the chosen shape so that it overhangs the edge of the map. Do not draw any portions that overhang." },
                    { 44, "Cost: [b]1[/b] coin - During the Draw phase, draw a 2x2 shape instead of one of the available shapes." },
                    { 45, "Cost: [b]0[/b] coins - During the Draw phase, draw an additional 1x1 shape adjacent to the drawn shape. Fill it with the same terrain type." },
                };

                _skillNumbers = new Dictionary<int, string>
                {
                    { 38, "S3"},
                    { 39, "S1" },
                    { 40, "S2" },
                    { 41, "S5" },
                    { 42, "S4" },
                    { 43, "S6" },
                    { 44, "S7" },
                    { 45, "S8" },
                };
            }
            else if (set == "Heroes")
            {
                _skillDescriptions = new Dictionary<int, string>
                {
                    { 38, "Cost: [b]1[/b] coin - During the Draw phase, draw a 1x1 square and fill it with both forest terrain and water terrain types."},
                    { 39, "Cost: [b]3[/b] coins - During the Draw phase, when an explore card with two options is revealed, draw both options."},
                    { 40, "Cost: [b]1[/b] coin - During the Draw phase, destroy any non-mountain space on your sheet."},
                    { 41, "Cost: [b]1[/b] coin - During the Draw phase, if an ambush card is not revealed, break the chosen shape into two separate shapes."},
                    { 42, $"Cost: [b]1[/b] coin - During the Draw phase, draw this hero adjacent to the drawn shape.{NL}[c]$$   B B{NL}    S$$[/c]"},
                    { 43, "Cost: [b]1[/b] coin - During the Draw phase, draw a 3x1 shape instead of one of the available shapes."},
                    { 44, "Cost: [b]1[/b] coin - During the Draw phase, draw a 1x1 square instead of one of the available shapes. Fill it with any non-mountain terrain type."},
                    { 45, "Cost: [b]0[/b] coins - During the Draw phase, if an ambush card is revealed, draw the shape with a +1/-1 square (minimum of 1)."},
                };

                _skillNumbers = new Dictionary<int, string>
                {
                    { 38, "S9" },
                    { 39, "S10" },
                    { 40, "S11" },
                    { 41, "S12" },
                    { 42, "S13" },
                    { 43, "S14" },
                    { 44, "S15" },
                    { 45, "S16" },
                };
            }
        }
    }
}