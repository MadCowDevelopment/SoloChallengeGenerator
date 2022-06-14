using System.Collections.Generic;
using System.Linq;
using System.Text;
using scg.Utils;

namespace scg.Generators.WelcomeTo
{
    public class CityPlansGenerator : TemplateGenerator
    {
        public override string Token { get; } = "<<CITY_PLAN_CARDS>>";
        public override string Apply(string template, string[] arguments)
        {
            return template.ReplaceFirst(Token, GenerateRandomizedCityPlans());
        }

        public string GenerateRandomizedCityPlans()
        {
            var sb = new StringBuilder();
            List<CityPlanCard> cityPlanLevel1Cards = _initCityPlanLevel1();
            List<CityPlanCard> cityPlanLevel2Cards = _initCityPlanLevel2();
            List<CityPlanCard> cityPlanLevel3Cards = _initCityPlanLevel3();
            List<CityPlanCard> cards = new List<CityPlanCard>{cityPlanLevel1Cards[0], cityPlanLevel2Cards[0],cityPlanLevel3Cards[0]};

            sb.Append(Constants.BLOCK_PREFIX);
            for (int i = 0; i < cards.Count; i++) {
                sb.Append(string.Format(Constants.CITY_PLAN_NAME, i + 1));
                CityPlanCard currCard = cards[i];

                foreach (int num in currCard.EstateSizes) {
                    sb.Append(Constants.CITY_PLAN_SIZE_PREFIX);
                    sb.Append(num).Append(" ");

                    for (int j = 0; j < num; j++) {
                        sb.Append(Constants.CITY_PLAN_BLOCK);
                    }
                    sb.Append(Constants.CITY_PLAN_SIZE_SUFFIX);
                }

                sb.Append(string.Format(Constants.CITY_PLAN_HIGHER, currCard.HigherPoints));
                sb.Append(string.Format(Constants.CITY_PLAN_LOWER, currCard.LowerPoints));
                sb.Append(Constants.CITY_SPACE_BETWEEN);
            }
            sb.Append(Constants.BLOCK_SUFFIX);

            return sb.ToString();
        }

         private List<CityPlanCard> _initCityPlanLevel1() {
            List<CityPlanCard> deck = new List<CityPlanCard>{
                    CityPlanCard.Create(new List<int>{1,1,1,1,1,1}, 8, 4, 1),
                    CityPlanCard.Create(new List<int>{2,2,2,2}, 8, 4, 1),
                    CityPlanCard.Create(new List<int>{3,3,3}, 8, 4, 1),
                    CityPlanCard.Create(new List<int>{4,4}, 6, 3, 1),
                    CityPlanCard.Create(new List<int>{5,5}, 8, 4, 1),
                    CityPlanCard.Create(new List<int>{6,6}, 10, 6, 1)
            };
            WelcomeToUtils.Shuffle(deck);
            return deck;
        }

        private List<CityPlanCard> _initCityPlanLevel2() {
            List<CityPlanCard> deck = new List<CityPlanCard>{
                    CityPlanCard.Create(new List<int>{1,1,1,6}, 11, 6, 2),
                    CityPlanCard.Create(new List<int>{3,6}, 8, 4, 2),
                    CityPlanCard.Create(new List<int>{5,2,2}, 10, 6, 2),
                    CityPlanCard.Create(new List<int>{3,3,4}, 12, 7, 2),
                    CityPlanCard.Create(new List<int>{4,5}, 9, 5, 2),
                    CityPlanCard.Create(new List<int>{4,1,1,1}, 9, 5, 2)
            };

            WelcomeToUtils.Shuffle(deck);
            return deck;
        }

        private List<CityPlanCard> _initCityPlanLevel3() {
            List<CityPlanCard> deck = new List<CityPlanCard>{
                    CityPlanCard.Create(new List<int>{1,2,6}, 12, 7, 3),
                    CityPlanCard.Create(new List<int>{1,4,5}, 13, 7, 3),
                    CityPlanCard.Create(new List<int>{3,4}, 7, 3, 3),
                    CityPlanCard.Create(new List<int>{2,5}, 7, 3, 3),
                    CityPlanCard.Create(new List<int>{1,2,2,3}, 11, 6, 3),
                    CityPlanCard.Create(new List<int>{2,3,5}, 13, 7, 3)
            };

            WelcomeToUtils.Shuffle(deck);
            return deck;
        }
        
    }
}