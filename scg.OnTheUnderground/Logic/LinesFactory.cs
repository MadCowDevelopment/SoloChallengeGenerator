using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using static scg.OnTheUnderground.Logic.LondonLocation;
namespace scg.OnTheUnderground.Logic
{
    public class LinesFactory
    {
        public IReadOnlyCollection<Line> CreateLines()
        {
            return new ReadOnlyCollection<Line>(
                new List<Line>
                {
                    new Line("Bakerloo", 25, Colors.SaddleBrown,
                        new List<LondonLocation>
                        {
                            HarrowAndWealdstone, Kenton, WillesdenJunction, Paddington, Marylebone,
                            BakerStreet, OxfordCircus, PiccadillyCircus, CharingCross, Waterloo, ElephantAndCastle
                        }),
                    new Line("Central", 5, Colors.Red,
                        new List<LondonLocation>
                        {
                            Ruislip, Greenford, Perivale, Alperton, WhiteCity, EalingBroadway, Acton, WhiteCity,
                            ShepherdsBush, NottingHillGate, MarbleArch, BondStreet, OxfordCircus, TottenhamCourtRoad,
                            Holborn, Bank, LiverpoolStreet, MileEnd, Stratford, Leytonstone, Woodford, Epping
                        }),
                    new Line("Circle", 20, Colors.Gold,
                        new List<LondonLocation>
                        {
                            GoldhawkRoad, ShepherdsBush, Paddington, Marylebone, BakerStreet, GreatPortlandStreet,
                            Euston, KingsCrossStPancras, Moorgate, LiverpoolStreet, Aldgate, Bank, Blackfriars,
                            CharingCross, Westminster, Victoria, SouthKensington, EarlsCourt, HighStreetKensington,
                            NottingHillGate, Paddington
                        }),
                    new Line("District", 10, Colors.Green,
                        new List<LondonLocation>
                        {
                            EalingBroadway, Acton, EalingCommon, ActonTown, TurnhamGreen, Hammersmith, EarlsCourt,
                            SouthKensington, Victoria, Westminster, CharingCross, Blackfriars, Bank, Aldgate, MileEnd,
                            Westham
                        }),
                    new Line("Docklands", 30, Colors.White,
                        new List<LondonLocation>
                        {
                            Waterloo, Borough, LondonBridge, Bank, Aldgate, Limehouse, CanningTown, Beckton, Stratford,
                            Westham, CanningTown, MileEnd, Limehouse, CanaryWharf, Greenwich, Lewisham
                        }),
                    new Line("Hammersmith & City", 15, Colors.DeepPink,
                        new List<LondonLocation>
                        {
                            Hammersmith, GoldhawkRoad, ShepherdsBush, Paddington, Marylebone, BakerStreet,
                            GreatPortlandStreet,
                            Euston, KingsCrossStPancras, Moorgate, LiverpoolStreet, Aldgate, MileEnd, Westham, Barking,
                            Upminster
                        }),
                    new Line("Jubilee", 15, Colors.Gray,
                        new List<LondonLocation>
                        {
                            Stanmore, WembleyPark, FinchleyRoad, BakerStreet, BondStreet, GreenPark, Westminster,
                            Waterloo, Borough, LondonBridge, CanadaWater, CanaryWharf, CanningTown, Westham, Stratford
                        }),
                    new Line("Metropolitan", 15, Colors.Purple,
                        new List<LondonLocation>
                        {
                            Watford, Northwood, Uxbridge, Ruislip, RaynersLane, HarrowOnTheHill, Amersham,
                            Richmansworth, Northwood, HarrowOnTheHill, Kenton, WembleyPark, FinchleyRoad, BakerStreet,
                            GreatPortlandStreet, Euston, KingsCrossStPancras, Moorgate, LiverpoolStreet, Aldgate
                        }),
                    new Line("Northern", 20, Colors.Black,
                        new List<LondonLocation>
                        {
                            Edgware, Hampstead, MorningtonCrescent, Euston, TottenhamCourtRoad, LeicesterSquare,
                            CharingCross, Waterloo, ElephantAndCastle, Stockwell, Morden, HighBarnet, Finchley,
                            KentishTown, MorningtonCrescent, ElephantAndCastle, Borough, LondonBridge, Bank, Moorgate,
                            Angel, KingsCrossStPancras, Euston
                        }),
                    new Line("Piccadilly", 5, Colors.Blue,
                        new List<LondonLocation>
                        {
                            RaynersLane, Sudbury, Alperton, Acton, EalingCommon, ActonTown, Heathrow, Hounslow,
                            ActonTown, TurnhamGreen, Hammersmith, EarlsCourt, SouthKensington, GreenPark,
                            PiccadillyCircus, LeicesterSquare, Holborn, KingsCrossStPancras, HollowayRoad, FinsburyPark,
                            ArnosGrove, Cockfosters
                        }),
                    new Line("Victoria", 20, Colors.DarkOrange,
                        new List<LondonLocation>
                        {
                            Brixton, Stockwell, Vauxhall, Pimlico, Victoria, GreenPark, OxfordCircus, Euston,
                            KingsCrossStPancras, Angel, HighburyAndIslington, FinsburyPark, WalthamstowCentral
                        })
                });
        }
    }
}