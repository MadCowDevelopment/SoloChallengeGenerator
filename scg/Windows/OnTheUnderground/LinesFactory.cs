using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using static scg.Games.OnTheUnderground.Logic.LondonLocation;
namespace scg.Games.OnTheUnderground.Logic
{
    public class LinesFactory
    {
        public IReadOnlyCollection<LondonLine> CreateLines()
        {
            return new ReadOnlyCollection<LondonLine>(
                new List<LondonLine>
                {
                    new LondonLine("Bakerloo", 25, Colors.SaddleBrown,
                        new List<LondonLocation>
                        {
                            HarrowAndWealdstone, Kenton, WillesdenJunction, Paddington, Marylebone,
                            BakerStreet, OxfordCircus, PiccadillyCircus, CharingCross, Waterloo, ElephantAndCastle
                        }),
                    new LondonLine("Central", 5, Colors.Red,
                        new List<LondonLocation>
                        {
                            Ruislip, Greenford, Perivale, Alperton, WhiteCity, EalingBroadway, Acton, WhiteCity,
                            ShepherdsBush, NottingHillGate, MarbleArch, BondStreet, OxfordCircus, TottenhamCourtRoad,
                            Holborn, Bank, LiverpoolStreet, MileEnd, Stratford, Leytonstone, Woodford, Epping
                        }),
                    new LondonLine("Circle", 20, Colors.Gold,
                        new List<LondonLocation>
                        {
                            GoldhawkRoad, ShepherdsBush, Paddington, Marylebone, BakerStreet, GreatPortlandStreet,
                            Euston, KingsCrossStPancras, Moorgate, LiverpoolStreet, Aldgate, Bank, Blackfriars,
                            CharingCross, Westminster, Victoria, SouthKensington, EarlsCourt, HighStreetKensington,
                            NottingHillGate, Paddington
                        }),
                    new LondonLine("District", 10, Colors.Green,
                        new List<LondonLocation>
                        {
                            EalingBroadway, Acton, EalingCommon, ActonTown, TurnhamGreen, Hammersmith, EarlsCourt,
                            SouthKensington, Victoria, Westminster, CharingCross, Blackfriars, Bank, Aldgate, MileEnd,
                            Westham
                        }),
                    new LondonLine("Docklands", 30, Colors.White,
                        new List<LondonLocation>
                        {
                            Waterloo, Borough, LondonBridge, Bank, Aldgate, Limehouse, CanningTown, Beckton, Stratford,
                            Westham, CanningTown, MileEnd, Limehouse, CanaryWharf, Greenwich, Lewisham
                        }),
                    new LondonLine("Hammersmith & City", 15, Colors.DeepPink,
                        new List<LondonLocation>
                        {
                            Hammersmith, GoldhawkRoad, ShepherdsBush, Paddington, Marylebone, BakerStreet,
                            GreatPortlandStreet,
                            Euston, KingsCrossStPancras, Moorgate, LiverpoolStreet, Aldgate, MileEnd, Westham, Barking,
                            Upminster
                        }),
                    new LondonLine("Jubilee", 15, Colors.Gray,
                        new List<LondonLocation>
                        {
                            Stanmore, WembleyPark, FinchleyRoad, BakerStreet, BondStreet, GreenPark, Westminster,
                            Waterloo, Borough, LondonBridge, CanadaWater, CanaryWharf, CanningTown, Westham, Stratford
                        }),
                    new LondonLine("Metropolitan", 15, Colors.Purple,
                        new List<LondonLocation>
                        {
                            Watford, Northwood, Uxbridge, Ruislip, RaynersLane, HarrowOnTheHill, Amersham,
                            Richmansworth, Northwood, HarrowOnTheHill, Kenton, WembleyPark, FinchleyRoad, BakerStreet,
                            GreatPortlandStreet, Euston, KingsCrossStPancras, Moorgate, LiverpoolStreet, Aldgate
                        }),
                    new LondonLine("Northern", 20, Colors.Black,
                        new List<LondonLocation>
                        {
                            Edgware, Hampstead, MorningtonCrescent, Euston, TottenhamCourtRoad, LeicesterSquare,
                            CharingCross, Waterloo, ElephantAndCastle, Stockwell, Morden, HighBarnet, Finchley,
                            KentishTown, MorningtonCrescent, ElephantAndCastle, Borough, LondonBridge, Bank, Moorgate,
                            Angel, KingsCrossStPancras, Euston
                        }),
                    new LondonLine("Piccadilly", 5, Colors.Blue,
                        new List<LondonLocation>
                        {
                            RaynersLane, Sudbury, Alperton, Acton, EalingCommon, ActonTown, Heathrow, Hounslow,
                            ActonTown, TurnhamGreen, Hammersmith, EarlsCourt, SouthKensington, GreenPark,
                            PiccadillyCircus, LeicesterSquare, Holborn, KingsCrossStPancras, HollowayRoad, FinsburyPark,
                            ArnosGrove, Cockfosters
                        }),
                    new LondonLine("Victoria", 20, Colors.DarkOrange,
                        new List<LondonLocation>
                        {
                            Brixton, Stockwell, Vauxhall, Pimlico, Victoria, GreenPark, OxfordCircus, Euston,
                            KingsCrossStPancras, Angel, HighburyAndIslington, FinsburyPark, WalthamstowCentral
                        })
                });
        }
    }
}