using System.Collections.Generic;
using static scg.Generators.OnTheUnderground.LondonLocation;
namespace scg.Generators.OnTheUnderground
{
    public class LondonDestinationDeckFactory : IDestinationDeckFactory
    {
        public DestinationDeck Create()
        {
            return new("London", new List<DestinationCard>
            {
                new(Acton, RouteType.Express, "A2"),
                new(ActonTown, RouteType.Standard, "A3", "Acton Town"),
                new(Alperton, RouteType.Standard, "A2"),
                new(Angel, RouteType.Express, "D2"),
                new(ArnosGrove, RouteType.Express, "D1", "Arnos Grove"),
                new(Bank, RouteType.Express, "D3"),
                new(BondStreet, RouteType.Express, "C2", "Bond Street"),
                new(Borough, RouteType.Standard, "D3"),
                new(CanadaWater, RouteType.Standard, "D3", "Canada Water"),
                new(CanaryWharf, RouteType.Express, "E3", "Canary Wharf"),
                new(CanningTown, RouteType.Standard, "E3", "Canning Town"),
                new(EalingCommon, RouteType.Standard, "A3", "Ealing Common"),
                new(EarlsCourt, RouteType.Express, "B3", "Earl's Court"),
                new(Finchley, RouteType.Standard, "D1"),
                new(FinchleyRoad, RouteType.Express, "B2", "Finchley Road"),
                new(GoldhawkRoad, RouteType.Standard, "B3", "Goldhawk Road"),
                new(GreatPortlandStreet, RouteType.Standard, "C2", "Great Portland Street"),
                new(GreenPark, RouteType.Standard, "C3", "Green Park"),
                new(Greenwich, RouteType.Express, "E3"),
                new(Hainault, RouteType.Express, "E1"),
                new(Hampstead, RouteType.Standard, "C1"),
                new(HighburyAndIslington, RouteType.Standard, "D2", "Highbury & Islington"),
                new(HighStreetKensington, RouteType.Standard, "B3", "High Street Kensington"),
                new(Holborn, RouteType.Express, "D2"),
                new(HollowayRoad, RouteType.Standard, "D2", "Holloway Road"),
                new(Hounslow, RouteType.Express, "A3"),
                new(Kenton, RouteType.Standard, "B1"),
                new(KewGardens, RouteType.Standard, "A3"),
                new(LeicesterSquare, RouteType.Express, "C3", "Leicester Square"),
                new(Leytonstone, RouteType.Standard, "E2"),
                new(MarbleArch, RouteType.Express, "B2", "Marble Arch"),
                new(MileEnd, RouteType.Standard, "E2", "Mile End"),
                new(Moorgate, RouteType.Standard, "D2"),
                new(MorningtonCrescent, RouteType.Standard, "C2", "Mornington Crescent"),
                new(NewburyPark, RouteType.Standard, "E2", "Newbury Park"),
                new(Northwood, RouteType.Standard, "A1"),
                new(OxfordCircus, RouteType.Express, "C2", "Oxford Circus"),
                new(Perivale, RouteType.Standard, "A2"),
                new(PiccadillyCircus, RouteType.Express, "C3", "Piccadilly Circus"),
                new(Pimlico, RouteType.Standard, "C3"),
                new(Putney, RouteType.Express, "B4"),
                new(RaynersLane, RouteType.Express, "A1", "Rayners Lane"),
                new(Ruislip, RouteType.Standard, "A1"),
                new(ShepherdsBush, RouteType.Express, "B2", "Shepherd's Bush"),
                new(SouthKensington, RouteType.Standard, "B3", "South Kensington"),
                new(Stockwell, RouteType.Express, "C4"),
                new(Sudbury, RouteType.Standard, "A2"),
                new(TottenhamCourtRoad, RouteType.Express, "C2", "Tottenham Court Road"),
                new(TurnhamGreen, RouteType.Express, "A3", "Turnham Green"),
                new(WembleyPark, RouteType.Standard, "B1", "Wembley Park"),
                new(Westham, RouteType.Standard, "E2"),
                new(Westminster, RouteType.Standard, "C3"),
                new(WhiteCity, RouteType.Standard, "A2", "White City"),
                new(WillesdenJunction, RouteType.Standard, "B2", "Willesden Junction"),
                new(Woodford, RouteType.Standard, "E1")
            });
        }
    }
}
