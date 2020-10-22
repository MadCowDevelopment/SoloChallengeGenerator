using System.Collections.Generic;

namespace scg.Logic
{
    public class DestinationDeckFactory
    {
        public DestinationDeck Create()
        {
            return new DestinationDeck(new List<DestinationCard>
            {
                new DestinationCard(LondonLocation.Acton, RouteType.Express, "A2"),
                new DestinationCard(LondonLocation.ActonTown, RouteType.Standard, "A3", "Acton Town"),
                new DestinationCard(LondonLocation.Alperton, RouteType.Standard, "A2"),
                new DestinationCard(LondonLocation.Angel, RouteType.Express, "D2"),
                new DestinationCard(LondonLocation.ArnosGrove, RouteType.Express, "D1", "Arnos Grove"),
                new DestinationCard(LondonLocation.Bank, RouteType.Express, "D3"),
                new DestinationCard(LondonLocation.BondStreet, RouteType.Express, "C2", "Bond Street"),
                new DestinationCard(LondonLocation.Borough, RouteType.Standard, "D3"),
                new DestinationCard(LondonLocation.CanadaWater, RouteType.Standard, "D3", "Canada Water"),
                new DestinationCard(LondonLocation.CanaryWharf, RouteType.Express, "E3", "Canary Wharf"),
                new DestinationCard(LondonLocation.CanningTown, RouteType.Standard, "E3", "Canning Town"),
                new DestinationCard(LondonLocation.EalingCommon, RouteType.Standard, "A3", "Ealing Common"),
                new DestinationCard(LondonLocation.EarlsCourt, RouteType.Express, "B3", "Earl's Court"),
                new DestinationCard(LondonLocation.Finchley, RouteType.Standard, "D1"),
                new DestinationCard(LondonLocation.FinchleyRoad, RouteType.Express, "B2", "Finchley Road"),
                new DestinationCard(LondonLocation.GoldhawkRoad, RouteType.Standard, "B3", "Goldhawk Road"),
                new DestinationCard(LondonLocation.GreatPortlandStreet, RouteType.Standard, "C2", "Great Portland Street"),
                new DestinationCard(LondonLocation.GreenPark, RouteType.Standard, "C3", "Green Park"),
                new DestinationCard(LondonLocation.Greenwich, RouteType.Express, "E3"),
                new DestinationCard(LondonLocation.Hainault, RouteType.Express, "E1"),
                new DestinationCard(LondonLocation.Hampstead, RouteType.Standard, "C1"),
                new DestinationCard(LondonLocation.HighburyAndIslington, RouteType.Standard, "D2", "Highbury & Islington"),
                new DestinationCard(LondonLocation.HighStreetKensington, RouteType.Standard, "B3", "High Street Kensington"),
                new DestinationCard(LondonLocation.Holborn, RouteType.Express, "D2"),
                new DestinationCard(LondonLocation.HollowayRoad, RouteType.Standard, "D2", "Holloway Road"),
                new DestinationCard(LondonLocation.Hounslow, RouteType.Express, "A3"),
                new DestinationCard(LondonLocation.Kenton, RouteType.Standard, "B1"),
                new DestinationCard(LondonLocation.KewGardens, RouteType.Standard, "A3"),
                new DestinationCard(LondonLocation.LeicesterSquare, RouteType.Express, "C3", "Leicester Square"),
                new DestinationCard(LondonLocation.Leytonstone, RouteType.Standard, "E2"),
                new DestinationCard(LondonLocation.MarbleArch, RouteType.Express, "B2", "Marble Arch"),
                new DestinationCard(LondonLocation.MileEnd, RouteType.Standard, "E2", "Mile End"),
                new DestinationCard(LondonLocation.Moorgate, RouteType.Standard, "D2"),
                new DestinationCard(LondonLocation.MorningtonCrescent, RouteType.Standard, "C2", "Mornington Crescent"),
                new DestinationCard(LondonLocation.NewburyPark, RouteType.Standard, "E2", "Newbury Park"),
                new DestinationCard(LondonLocation.Northwood, RouteType.Standard, "A1"),
                new DestinationCard(LondonLocation.OxfordCircus, RouteType.Express, "C2", "Oxford Circus"),
                new DestinationCard(LondonLocation.Perivale, RouteType.Standard, "A2"),
                new DestinationCard(LondonLocation.PiccadillyCircus, RouteType.Express, "C3", "Piccadilly Circus"),
                new DestinationCard(LondonLocation.Pimlico, RouteType.Standard, "C3"),
                new DestinationCard(LondonLocation.Putney, RouteType.Express, "B4"),
                new DestinationCard(LondonLocation.RaynersLane, RouteType.Express, "A1", "Rayners Lane"),
                new DestinationCard(LondonLocation.Ruislip, RouteType.Standard, "A1"),
                new DestinationCard(LondonLocation.ShepherdsBush, RouteType.Express, "B2", "Shepherd's Bush"),
                new DestinationCard(LondonLocation.SouthKensington, RouteType.Standard, "B3", "South Kensington"),
                new DestinationCard(LondonLocation.Stockwell, RouteType.Express, "C4"),
                new DestinationCard(LondonLocation.Sudbury, RouteType.Standard, "A2"),
                new DestinationCard(LondonLocation.TottenhamCourtRoad, RouteType.Express, "C2", "Tottenham Court Road"),
                new DestinationCard(LondonLocation.TurnhamGreen, RouteType.Express, "A3", "Turnham Green"),
                new DestinationCard(LondonLocation.WembleyPark, RouteType.Standard, "B1", "Wembley Park"),
                new DestinationCard(LondonLocation.Westham, RouteType.Standard, "E2"),
                new DestinationCard(LondonLocation.Westminster, RouteType.Standard, "C3"),
                new DestinationCard(LondonLocation.WhiteCity, RouteType.Standard, "A2", "White City"),
                new DestinationCard(LondonLocation.WillesdenJunction, RouteType.Standard, "B2", "Willesden Junction"),
                new DestinationCard(LondonLocation.Woodford, RouteType.Standard, "E1")
            });
        }
    }
}