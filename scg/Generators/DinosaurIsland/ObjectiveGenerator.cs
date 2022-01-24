using System.Collections.Generic;
using System.Text;
using scg.Framework;
using scg.Utils;

namespace scg.Generators.DinosaurIsland
{
    public class ObjectiveGenerator : TemplateGenerator
    {
        private readonly BuildingData _buildingData;

        private readonly Dictionary<int, string> _objectives = new()
        {
            { 1, "2 of each attraction" },
            { 2, "4 Food attractions" },
            { 3, "4 Ride attractions" },
            { 4, "4 Merch attractions" },
            { 5, "Specialists A, B and C" },
            { 6, "Buildings A, B and C" },
            { 7, "1 herbivore, 1 small carnivore and 1 large carnivore paddock" },
            { 8, "3 herbivore paddocks" },
            { 9, "3 large carnivore paddocks" },
            { 10, "3 small carnivore paddocks" },
        };

        public ObjectiveGenerator(BuildingData buildingData)
        {
            _buildingData = buildingData;
        }

        public override string Token { get; } = "<<DINOSAUR_OBJECTIVES>>";
        public override string Apply(string template, string[] arguments)
        {
            var builder = new StringBuilder();

            var buildings = _buildingData.GetAndSkipTakenBuildings("AI", 3);
            foreach (var building in buildings)
            {
                var objective = _objectives[building.Id];
                builder.AppendLine(objective);
            }

            return template.ReplaceFirst(Token, builder.ToString());
        }
    }
}