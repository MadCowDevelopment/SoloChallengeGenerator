using scg.Generators.WelcomeTo;

namespace scg.Generators.WelcomeTo
{
    public class ConstructionCard
    {
        public int number;
        public Figure figure;

        private ConstructionCard(int number, Figure figure)
        {
            this.number = number;
            this.figure = figure;
        }

        public static ConstructionCard create(int number, Figure figure)
        {
            return new ConstructionCard(number, figure);
        }
    }
}