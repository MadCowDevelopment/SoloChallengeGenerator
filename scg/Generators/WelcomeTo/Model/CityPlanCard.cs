using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Utils;

namespace scg.Generators.WelcomeTo
{
    public class CityPlanCard
    {
        public List<int> EstateSizes { get; }
        public int HigherPoints { get; }
        public int LowerPoints { get; }

        public int Level { get; }

        private CityPlanCard(List<int> estateSizes, int higherPoints, int lowerPoints, int level)
        {
            EstateSizes = estateSizes;
            HigherPoints = higherPoints;
            LowerPoints = lowerPoints;
            Level = level;
        }

        public static CityPlanCard Create(List<int> estateSizes, int firstPlacePoints, int secondPlacePoints, int level)
        {
            return new CityPlanCard(estateSizes, firstPlacePoints, secondPlacePoints, level);
        }
    }
}