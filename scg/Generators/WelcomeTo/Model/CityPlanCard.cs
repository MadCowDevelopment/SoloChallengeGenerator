using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Utils;

namespace scg.Generators.WelcomeTo
{
    public class CityPlanCard
    {
        public List<int> estateSizes;
        public int higherPoints;
        public int lowerPoints;

        public int level;

        private CityPlanCard(List<int> estateSizes, int higherPoints, int lowerPoints, int level)
        {
            this.estateSizes = estateSizes;
            this.higherPoints = higherPoints;
            this.lowerPoints = lowerPoints;
            this.level = level;
        }

        public static CityPlanCard create(List<int> estateSizes, int firstPlacePoints, int secondPlacePoints, int level)
        {
            return new CityPlanCard(estateSizes, firstPlacePoints, secondPlacePoints, level);
        }
    }
}