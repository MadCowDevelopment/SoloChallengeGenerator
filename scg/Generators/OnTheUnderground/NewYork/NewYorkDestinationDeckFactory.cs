using System.Collections.Generic;
using static scg.Generators.OnTheUnderground.NewYork.NewYorkLocation;

namespace scg.Generators.OnTheUnderground.NewYork;

public class NewYorkDestinationDeckFactory : IDestinationDeckFactory
{
    public DestinationDeck Create()
    {
        return new("NewYork", new List<DestinationCard>
        {
            new(OneHundredFiftyFiveSt, "A1", "155 St"),
            new(YankeeStadium, "B1", "Yankee Stadium"),
            new(E180St, "B1", "E 180 St"),
            new(OneHundredFourtyFiveSt, "A2", "145 St"),
            new(CathedralPkwy, "A2", "Cathedral Pkwy"),
            new(CentralParkNorth, "A2", "Central Park North"),
            new(MuseumOfNaturalHistory, "A2", "Museum of Natural History"),
            new(MuseumOfNaturalHistory, "A2", "Museum of Natural History"),
            new(FreemanSt, "B2", "Freeman St"),
            new(Parkchester, "B2"),
            new(HuntsPointAv, "B2", "Hunts Point Av"),
            new(EightySixSt, "B2", "86 St"),
            new(SteinwaySt, "C2", "Steinway St"),
            new(JacksonHtsRooseveltAv, "C2", "Jackson Hts Roosevelt Av"),
            new(GrandAvNewtown, "C2", "Grand Av Newtown"),
            new(GrandAvNewtown, "C2", "Grand Av Newtown"),
            new(KewGardensUnionTurnpike, "D2", "Kew Gardens Union Turnpike"),
            new(ColumbusCircle, "A3", "Columbus Circle"),
            new(FiftySevenSt, "A3", "57 St"),
            new(FourteenSt8Av, "A3", "14 St - 8 Av"),
            new(FourteenSt7Av, "A3", "14 St - 7 Av"),
            new(LexingtonAv, "B3", "Lexington Av"),
            new(LexingtonAv, "B3", "Lexington Av"),
            new(QueensPlaza, "B3", "Queens Plaza"),
            new(UnionSq, "B3", "Union Sq"),
            new(GreenpointAv, "B3", "Greenpoint Av"),
            new(Woodside, "C3", "Woodside"),
            new(GrandSt, "C3", "Grand St"),
            new(MyrtleWyckoffAvs, "C3", "Myrtle-Wyckoff Avs"),
            new(WoodhavenBlvd, "D3", "Woodhaven Blvd"),
            new(CrescentSt, "D3", "Crescent St"),
            new(RockawayBlvd, "D3", "Rockaway Blvd"),
            new(CanalSt, "A4", "Canal St"),
            new(MarcyAv, "B4", "Marcy Av"),
            new(BrooklynBridgeCityHall, "B4", "Brooklyn Bridge City Hall"),
            new(YorkSt, "B4", "York St"),
            new(FultonSt, "B4", "Fulton St"),
            new(BoroughHall, "B4", "Borough Hall"),
            new(BoroughHall, "B4", "Borough Hall"),
            new(FlushingAv, "C4", "Flushing Av"),
            new(GatesAv, "C4", "Gates Av"),
            new(GrandArmyPlaza, "C4", "Grand Army Plaza"),
            new(EuclidAv, "D4", "Euclid Av"),
            new(CrownHtsUticaAv, "D4", "Crown Hts Utica Av"),
            new(CrownHtsUticaAv, "D4", "Crown Hts Utica Av"),
            new(WhitehallSt, "B5", "Whitehall St"),
            new(WhitehallSt, "B5", "Whitehall St"),
            new(CarrollSt, "B5", "Carroll St"),
            new(FourAv9Street, "C5", "4 Av - 9 Street"),
            new(ChurchAv, "C5", "Church Av"),
            new(BayRidgeAv, "C5", "Bay Ridge Av"),
            new(NewUtrechtAv, "C5", "New Utrecht Av"),
            new(KingsHighway, "C5", "Kings Highway"),
            new(KingsHighway, "C5", "Kings Highway")
        });
    }
}
