namespace scg.Generators.WelcomeTo;

public class ConstructionCard
{
    public int Number { get; }
    public Figure Figure { get; }

    private ConstructionCard(int number, Figure figure)
    {
        Number = number;
        Figure = figure;
    }

    public static ConstructionCard Create(int number, Figure figure)
    {
        return new ConstructionCard(number, figure);
    }
}