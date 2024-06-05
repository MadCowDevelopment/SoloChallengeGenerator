using System.Collections.Generic;
using System.Collections.ObjectModel;
using static scg.Generators.OnTheUnderground.NewYork.NewYorkLocation;

namespace scg.Generators.OnTheUnderground.NewYork;

public static class NewYorkLinesFactory
{
    public static IReadOnlyCollection<NewYorkLine> Create()
    {
        return new ReadOnlyCollection<NewYorkLine>(
            new List<NewYorkLine>
            {
                 new NewYorkLine(1, "2", 0, NewYorkLineIcon.Triangle,
                    new List<NewYorkLocation>
                    {
                        E180St, FreemanSt, GrandConcourse, GrandConcourseSouthBridge, CentralParkNorth, CathedralPkwy,
                        MuseumOfNaturalHistory, ColumbusCircle, TimesSq, FourteenSt7Av, ChristopherStSheridanSq, CanalSt,
                        ChambersStWorldTradeCenter, FultonSt, WhitehallSt, BoroughHallSouthEastBridge, BoroughHall,
                        AtlanticAvBarclaysCtr, GrandArmyPlaza, BotanicGarden, FlatbushAvBrooklynCollege
                    }),
                 new NewYorkLine(2, "A C", 5, NewYorkLineIcon.Triangle,
                    new List<NewYorkLocation>
                    {
                        OneHundredFourtyFiveSt, CathedralPkwy, MuseumOfNaturalHistory, ColumbusCircle, PortAuthorityBusTerminal,
                        FourteenSt8Av, ChristopherStSheridanSq, WashSq, CanalSt, ChambersStWorldTradeCenter, FultonSt,
                        BoroughHallSouthBridge, BoroughHall, AtlanticAvBarclaysCtr, FranklinAv, BroadwayJunction,
                        EuclidAv, RockawayBlvd, OzoneParkLeffertsBlvd
                    }),
                 new NewYorkLine(3, "B D", 5, NewYorkLineIcon.Triangle,
                    new List<NewYorkLocation>
                    {
                        Woodlawn, YankeeStadium, YankeeStadiumBridge, OneHundredFiftyFiveSt, OneHundredFourtyFiveSt,
                        CathedralPkwy, MuseumOfNaturalHistory, ColumbusCircle, PortAuthorityBusTerminal, TimesSq, BryantPk,
                        FourteenSt6Av, WashSq, BwayLafayetteSt, BrooklynBridgeCityHall, YorkStSouthBridge, YorkSt, AtlanticAvBarclaysCtr,
                        GrandArmyPlaza, ProspectPark, KingsHighway
                    }),
                 new NewYorkLine(4, "R", 0, NewYorkLineIcon.Square,
                    new List<NewYorkLocation>
                    {
                        ForestHills, GrandAvNewtown, JacksonHtsRooseveltAv, SteinwaySt, QueensPlaza, QueensPlazaBridge,
                        LexingtonAv, FiftySevenSt, TimesSq, FourteenSt6Av, UnionSq, BwayLafayetteSt, BrooklynBridgeCityHall,
                        ChambersStWorldTradeCenter, SouthFerry, WhitehallSt, BoroughHallSouthEastBridge, BoroughHall,
                        AtlanticAvBarclaysCtr, FourAv9Street, BayRidgeAv
                    }),
                 new NewYorkLine(5, "G 7", 5, NewYorkLineIcon.Square,
                    new List<NewYorkLocation>
                    {
                        FlushingMainSt, JunctionBlvd, JacksonHtsRooseveltAv, Woodside, QueensPlaza, HuntersPointAv, HuntersPointAvBridge,
                        GrandCentral, BryantPk, TimesSq, PortAuthorityBusTerminal, HuntersPointAv, GreenpointAv, FlushingAv,
                        FranklinAv, AtlanticAvBarclaysCtr, BoroughHall, CarrollSt, FourAv9Street, ChurchAv
                    }),
                 new NewYorkLine(6, "E", 10, NewYorkLineIcon.Square,
                    new List<NewYorkLocation>
                    {
                        JamaicaCentreParsonsArcher, SutphinBlvdArcherAvJFKAirport, KewGardensUnionTurnpike, ForestHills,
                        GrandAvNewtown, JacksonHtsRooseveltAv, SteinwaySt, QueensPlaza, HuntersPointAv, HuntersPointAvBridge,
                        GrandCentral, BryantPk, TimesSq, PortAuthorityBusTerminal, FourteenSt8Av
                    }),
                 new NewYorkLine(7, "M 6", 5, NewYorkLineIcon.Circle,
                    new List<NewYorkLocation>
                    {
                        PelhamBayPark, Parkchester, HuntsPointAv, GrandConcourseEastBridge, EightySixSt, LexingtonAv, GrandCentral,
                        UnionSq, BwayLafayetteSt, BrooklynBridgeCityHall, FultonSt, BwayLafayetteSt, MarcyAvBridge, MarcyAv,
                        FlushingAv, MyrtleWyckoffAvs, MiddleVillageMetropolitanAv
                    }),
                 new NewYorkLine(8, "4 5", 10, NewYorkLineIcon.Circle,
                    new List<NewYorkLocation>
                    {
                        GrandConcourse, GrandConcourseEastBridge, EightySixSt, LexingtonAv, GrandCentral, UnionSq, BwayLafayetteSt,
                        BrooklynBridgeCityHall, FultonSt, SouthFerry, WhitehallSt, BoroughHallSouthEastBridge, BoroughHall,
                        AtlanticAvBarclaysCtr, GrandArmyPlaza, BotanicGarden
                    }),
                 new NewYorkLine(9, "J Z", 15, NewYorkLineIcon.None,
                    new List<NewYorkLocation>
                    {
                        JamaicaCentreParsonsArcher, SutphinBlvdArcherAvJFKAirport, WoodhavenBlvd, CrescentSt, BroadwayJunction,
                        GatesAv, FlushingAv, MarcyAv, MarcyAvBridge, BwayLafayetteSt, BrooklynBridgeCityHall, FultonSt, WhitehallSt
                    }),
                 new NewYorkLine(10, "L", 15, NewYorkLineIcon.None,
                    new List<NewYorkLocation>
                    {
                        FourteenSt8Av, FourteenSt7Av, FourteenSt6Av, UnionSq, GreenpointAvBridge, GreenpointAv, GrandSt,
                        MyrtleWyckoffAvs, BroadwayJunction, CrownHtsUticaAv, CanarsleRockawayPkwy

                    }),
            });
    }
}
