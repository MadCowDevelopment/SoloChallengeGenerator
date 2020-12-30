using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Framework;

namespace scg.Generators
{
    internal class SkillsGenerator : TemplateGenerator
    {
        private readonly BuildingData _buildingData;
        private readonly Dictionary<int, string> _skillDescriptions;

        public SkillsGenerator(BuildingData buildingData)
        {
            _buildingData = buildingData;

            _skillDescriptions = new Dictionary<int, string>
            {
                { 38, "Cost: [b]1[/b] coin - During the Draw phase, draw an additional 2x1 shape adjacent to a monster space. Fill it with an available terrain type."},
                { 39, "Cost: [b]2[/b] coins - During the Draw phase, if an ambush card is revealed, the shape drawn on your map sheet is a 2x1 shape instead of the depicted shape." },
                { 40, "Cost: [b]3[/b] coins - During the Draw phase, if an ambush card is not revealed, draw the chosen shape a second time. Fill it with the same terrain type." },
                { 41, "Cost: [b]0[/b] coins - During the Draw phase, fill the chosen shape with village terrain instead of an available type." },
                { 42, "Cost: [b]1[/b] coin - At any time, draw a 1x1 square and fill it with both farm terrain and village terrain types." },
                { 43, "Cost: [b]0[/b] coins - During the Draw phase, draw the chosen shape so that it overhangs the edge of the map. Do not draw any portions that overhang." },
                { 44, "Cost: [b]1[/b] coin - During the Draw phase, draw a 2x2 shape instead of one of the available shapes." },
                { 45, "Cost: [b]0[/b] coins - During the Draw phase, draw an additional 1x1 shape adjacent to the drawn shape. Fill it with the same terrain type." }
            };
        }

        public override string Token { get; } = "<<SKILL_CARDS>>";

        public override string Apply(string template, string[] arguments)
        {
            var skills = _buildingData.GetAndSkipTakenBuildings("Skill", 3).ToList();

            var builder = new StringBuilder();
            builder.Append("[size=11]");
            builder.AppendLine($"A) {skills[0].ToPostFormatWithoutDuplicateTranslations()}");
            builder.AppendLine(_skillDescriptions[skills[0].Id]);
            builder.AppendLine($"B) {skills[1].ToPostFormatWithoutDuplicateTranslations()}");
            builder.AppendLine(_skillDescriptions[skills[1].Id]);
            builder.AppendLine($"C) {skills[2].ToPostFormatWithoutDuplicateTranslations()}");
            builder.AppendLine(_skillDescriptions[skills[2].Id]);
            builder.Append("[/size]");

            return template.Replace(Token, builder.ToString());
        }
    }
}