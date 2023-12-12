using scg.Framework;

namespace scg.Generators;

internal class ResetTakenBuildingsGenerator : TemplateGenerator
{
    private readonly BuildingData _buildingData;

    public ResetTakenBuildingsGenerator(BuildingData buildingData)
    {
        _buildingData = buildingData;
    }

    public override string Token { get; } = "<<RESET_TAKEN_BUILDINGS>>";
    public override string Apply(string template, string[] arguments)
    {
        _buildingData.ResetTakenBuildings();
        return template;
    }
}