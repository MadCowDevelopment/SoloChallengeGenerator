using System.Collections.Generic;
using System.Collections.ObjectModel;
using static scg.Logic.LondonLocation;
namespace scg.Logic
{
    public class LinesFactory
    {
        public IReadOnlyCollection<Line> CreateLines()
        {
            return new ReadOnlyCollection<Line>(
                new List<Line>
                {
                    new Line("Bakerloo", 25,
                        new List<LondonLocation>
                        {
                            HarrowAndWealdstone, Kenton, WillesdenJunction, Paddington, MarbleArch, MaryLebone,
                            BakerStreet, OxfordCircus, PiccadillyCircus, CharingCross, Waterloo, ElephantAndCastle
                        }),
                    new Line("Central", 5,
                        new List<LondonLocation>
                        {
                            Ruislip, Greenford, Perivale, Alperton, WhiteCity, EalingBroadway, Acton, WhiteCity,
                            ShepherdsBush, NottingHillGate, MarbleArch, BondStreet, OxfordCircus, TottenhamCourtRoad,
                            Holborn, Bank, LiverpoolStreet, MileEnd, Stratford, Leytonstone, Woodford, Epping
                        }),
                    new Line("Circle", 20,
                        new List<LondonLocation>
                        {
                            GoldhawkRoad, ShepherdsBush, Paddington, MaryLebone, BakerStreet, GreatPortlandStreet,
                            Eustone, KingsCrossStPancras, Moorgate, LiverpoolStreet, Aldgate, Bank, Blackfriars,
                            CharingCross, Westminster, Victoria, SouthKensington, EarlsCourt, HighStreetKensington,
                            NottingHillGate, Paddington
                        }),
                    new Line("District", 10,
                        new List<LondonLocation>
                        {
                            EalingBroadway, Acton, EalingCommon, ActonTown, TurnhamGreen, Hammersmith, EarlsCourt,
                            SouthKensington, Victoria, Westminster, CharingCross, Blackfriars, Bank, Aldgate, MileEnd,
                            Westham
                        }),
                    new Line("Docklands", 30,
                        new List<LondonLocation>
                        {
                            Waterloo, Borough, LondonBridge, Bank, Aldgate, Limehouse, CanningTown, Beckton, Stratford,
                            Westham, CanningTown, MileEnd, Limehouse, CanaryWharf, Greenwich, Lewisham
                        }),
                    new Line("Hammersmith & City", 15,
                        new List<LondonLocation>
                        {
                            GoldhawkRoad, ShepherdsBush, Paddington, MaryLebone, BakerStreet, GreatPortlandStreet,
                            Eustone, KingsCrossStPancras, Moorgate, LiverpoolStreet, Aldgate, MileEnd, Westham, Barking,
                            Upminster
                        }),
                    new Line("Jubilee", 15,
                        new List<LondonLocation>
                        {
                            Stanmore, WembleyPark, FinchleyRoad, BakerStreet, BondStreet, GreenPark, Westminster,
                            Waterloo, Borough, LondonBridge, CanadaWater, CanaryWharf, CanningTown, Westham, Stratford
                        }),
                    new Line("Metropolitan", 15,
                        new List<LondonLocation>
                        {
                            Watford, Northwood, Uxbridge, Ruislip, RaynersLane, HarrowOnTheHill, Amersham,
                            Richmansworth, Northwood, HarrowOnTheHill, Kenton, WembleyPark, FinchleyRoad, BakerStreet,
                            GreatPortlandStreet, Eustone, KingsCrossStPancras, Moorgate, LiverpoolStreet, Aldgate
                        }),
                    new Line("Northern", 20,
                        new List<LondonLocation>
                        {
                            Edgware, Hampstead, MorningtonCrescent, Eustone, TottenhamCourtRoad, LeicesterSquare,
                            CharingCross, Waterloo, ElephantAndCastle, Stockwell, Morden, HighBarnet, Finchley,
                            KentishTown, MorningtonCrescent, Eustone, KingsCrossStPancras, Angel, Moorgate, Bank,
                            LondonBridge, Borough, ElephantAndCastle
                        }),
                    new Line("Piccadilly", 5,
                        new List<LondonLocation>
                        {
                            RaynersLane, Sudbury, Alperton, Acton, EalingCommon, ActonTown, Heathrow, Hounslow,
                            ActonTown, TurnhamGreen, Hammersmith, EarlsCourt, SouthKensington, GreenPark,
                            PiccadillyCircus, LeicesterSquare, Holborn, KingsCrossStPancras, HollowayRoad, FinsburyPark,
                            ArnosGrove, Cockfosters
                        }),
                    new Line("Victoria", 20,
                        new List<LondonLocation>
                        {
                            Brixton, Stockwell, Vauxhall, Pimlico, Victoria, GreenPark, OxfordCircus, Eustone,
                            KingsCrossStPancras, Angel, HighburyAndIslington, FinsburyPark, WalthamstowCentral
                        })
                });
        }
    }
}