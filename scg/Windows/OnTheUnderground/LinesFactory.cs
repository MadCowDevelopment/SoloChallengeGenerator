using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using static scg.Windows.OnTheUnderground.LondonLocation;

namespace scg.Windows.OnTheUnderground
{
    public class LinesFactory
    {
        public IReadOnlyCollection<LondonLine> CreateLines()
        {
            return new ReadOnlyCollection<LondonLine>(
                new List<LondonLine>
                {
                    new LondonLine(1, "Bakerloo", 25, Colors.SaddleBrown, "brown",
                        new List<LondonLocation>
                        {
                            HarrowAndWealdstone, Kenton, WillesdenJunction, Paddington, Marylebone,
                            BakerStreet, OxfordCircus, PiccadillyCircus, CharingCross, Waterloo, ElephantAndCastle
                        }),
                    new LondonLine(2, "Central", 5, Colors.Red, "red",
                        new List<LondonLocation>
                        {
                            Ruislip, Greenford, Perivale, Alperton, WhiteCity, EalingBroadway, Acton, WhiteCity,
                            ShepherdsBush, NottingHillGate, MarbleArch, BondStreet, OxfordCircus, TottenhamCourtRoad,
                            Holborn, Bank, LiverpoolStreet, MileEnd, Stratford, Leytonstone, Woodford, Epping
                        }),
                    new LondonLine(3,"Circle", 20, Colors.Gold, "yellow",
                        new List<LondonLocation>
                        {
                            GoldhawkRoad, ShepherdsBush, Paddington, Marylebone, BakerStreet, GreatPortlandStreet,
                            Euston, KingsCrossStPancras, Moorgate, LiverpoolStreet, Aldgate, Bank, Blackfriars,
                            CharingCross, Westminster, Victoria, SouthKensington, EarlsCourt, HighStreetKensington,
                            NottingHillGate, Paddington
                        }),
                    new LondonLine(4,"District", 10, Colors.Green, "green",
                        new List<LondonLocation>
                        {
                            EalingBroadway, Acton, EalingCommon, ActonTown, TurnhamGreen, Hammersmith, EarlsCourt,
                            SouthKensington, Victoria, Westminster, CharingCross, Blackfriars, Bank, Aldgate, MileEnd,
                            Westham
                        }),
                    new LondonLine(5, "Docklands", 30, Colors.White, "white",
                        new List<LondonLocation>
                        {
                            Waterloo, Borough, LondonBridge, Bank, Aldgate, Limehouse, CanningTown, Beckton, Stratford,
                            Westham, CanningTown, MileEnd, Limehouse, CanaryWharf, Greenwich, Lewisham
                        }),
                    new LondonLine(6, "Hammersmith & City", 15, Colors.DeepPink, "pink",
                        new List<LondonLocation>
                        {
                            Hammersmith, GoldhawkRoad, ShepherdsBush, Paddington, Marylebone, BakerStreet,
                            GreatPortlandStreet,
                            Euston, KingsCrossStPancras, Moorgate, LiverpoolStreet, Aldgate, MileEnd, Westham, Barking,
                            Upminster
                        }),
                    new LondonLine(7, "Jubilee", 15, Colors.Gray, "gray",
                        new List<LondonLocation>
                        {
                            Stanmore, WembleyPark, FinchleyRoad, BakerStreet, BondStreet, GreenPark, Westminster,
                            Waterloo, Borough, LondonBridge, CanadaWater, CanaryWharf, CanningTown, Westham, Stratford
                        }),
                    new LondonLine(8, "Metropolitan", 15, Colors.Purple, "purple",
                        new List<LondonLocation>
                        {
                            Watford, Northwood, Uxbridge, Ruislip, RaynersLane, HarrowOnTheHill, Amersham,
                            Richmansworth, Northwood, HarrowOnTheHill, Kenton, WembleyPark, FinchleyRoad, BakerStreet,
                            GreatPortlandStreet, Euston, KingsCrossStPancras, Moorgate, LiverpoolStreet, Aldgate
                        }),
                    new LondonLine(9, "Northern", 20, Colors.Black, "black",
                        new List<LondonLocation>
                        {
                            Edgware, Hampstead, MorningtonCrescent, Euston, TottenhamCourtRoad, LeicesterSquare,
                            CharingCross, Waterloo, ElephantAndCastle, Stockwell, Morden, HighBarnet, Finchley,
                            KentishTown, MorningtonCrescent, ElephantAndCastle, Borough, LondonBridge, Bank, Moorgate,
                            Angel, KingsCrossStPancras, Euston
                        }),
                    new LondonLine(10, "Piccadilly", 5, Colors.Blue, "blue",
                        new List<LondonLocation>
                        {
                            RaynersLane, Sudbury, Alperton, Acton, EalingCommon, ActonTown, Heathrow, Hounslow,
                            ActonTown, TurnhamGreen, Hammersmith, EarlsCourt, SouthKensington, GreenPark,
                            PiccadillyCircus, LeicesterSquare, Holborn, KingsCrossStPancras, HollowayRoad, FinsburyPark,
                            ArnosGrove, Cockfosters
                        }),
                    new LondonLine(11, "Victoria", 20, Colors.DarkOrange, "orange",
                        new List<LondonLocation>
                        {
                            Brixton, Stockwell, Vauxhall, Pimlico, Victoria, GreenPark, OxfordCircus, Euston,
                            KingsCrossStPancras, Angel, HighburyAndIslington, FinsburyPark, WalthamstowCentral
                        })
                });
        }
    }
}