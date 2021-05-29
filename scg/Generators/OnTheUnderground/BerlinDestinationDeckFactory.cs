using System.Collections.Generic;
using static scg.Generators.OnTheUnderground.BerlinLocation;

namespace scg.Generators.OnTheUnderground
{
    public class BerlinDestinationDeckFactory : IDestinationDeckFactory
    {
        public DestinationDeck Create()
        {
            return new("Berlin", new List<DestinationCard>
            {
                new(BayerischerPlatz, RouteType.Standard, "B3","Bayerischer Platz"),
                new(Bergfelde, RouteType.Standard, "B1"),
                new(BismarckStr, RouteType.Standard, "B2", "Bismarck Str."),
                new(BornholmerStr, RouteType.Standard, "C1", "Bornholmer Str."),
                new(BotanischerGarten, RouteType.Standard, "B4", "Botanischer Garten"),
                new(Bundesplatz, RouteType.Express, "B3"),
                new(Charlottenburg, RouteType.Express, "B3"),
                new(DahlemDorf, RouteType.Standard, "A4", "Dahlem-Dorf"),
                new(FehrbellinerPlatz, RouteType.Standard, "B3", "Fehrbelliner Platz"),
                new(FrankfurterAllee, RouteType.Express, "D2", "Frankfurter Allee"),
                new(FriedrichsfeldeOst, RouteType.Standard, "E2", "Friedrichsfelde Ost"),
                new(Gruenbergallee, RouteType.Standard, "E4", "Grünbergallee"),
                new(HalleschesTor, RouteType.Express, "C3", "Hallesches Tor"),
                new(HeidelbergerPlatz, RouteType.Express, "B3", "Heidelberger Platz"),
                new(Hermannplatz, RouteType.Standard, "C3"),
                new(JohannisthalerChaussee, RouteType.Standard, "D4", "Johannisthaler Chaussee"),
                new(KarlBonhoefferNervenklinik, RouteType.Express, "B1", "Karl-Bonhoeffer-Nervenklinik"),
                new(Karlshorst, RouteType.Standard, "D3"),
                new(KottbusserTor, RouteType.Express, "C3", "Kottbusser Tor"),
                new(LandsbergerAllee, RouteType.Express, "D2", "Landsberger Allee"),
                new(Leopoldplatz, RouteType.Standard, "B1"),
                new(Marienfelde, RouteType.Standard, "C4"),
                new(Marzahn, RouteType.Standard, "E1"),
                new(Mehringdamm, RouteType.Standard, "C3"),
                new(MesseNord, RouteType.Express, "A2", "Messe Nord / ICC"),
                new(MesseSued, RouteType.Standard, "A3", "Messe Süd"),
                new(Mierendorffplatz, RouteType.Standard, "B2", "Mierendorff-Platz"),
                new(Moeckernbruecke, RouteType.Express, "C3", "Möckernbrücke"),
                new(MuehlenbeckMoenchMuehle, RouteType.Standard, "C1", "Mühlenbeck-Mönchmühle"),
                new(Neukoelln, RouteType.Express, "D3", "Neukölln"),
                new(Nollendorfplatz, RouteType.Express, "B3", "Nollendorf-Platz"),
                new(Olympiastadion, RouteType.Standard, "A2"),
                new(Pankow, RouteType.Standard, "C1"),
                new(PotsdamerPlatz, RouteType.Standard, "C2", "Potsdamer Platz"),
                new(PrenzlauerAllee, RouteType.Express, "C2", "Prenzlauer Allee"),
                new(Priesterweg, RouteType.Express, "C4"),
                new(SamariterStr, RouteType.Standard, "D2", "Samariterstr."),
                new(Schoeneberg, RouteType.Express, "B3", "Schöneberg"),
                new(SchoenhauserAllee, RouteType.Express, "C2", "Schönhauser Allee"),
                new(Siemensdamm, RouteType.Standard, "A"),
                new(Springpfuhl, RouteType.Express, "E2"),
                new(Stadtmitte, RouteType.Standard, "C2"),
                new(StrausbergerPlatz, RouteType.Standard, "C2", "Strausberger Platz"),
                new(Tempelhof, RouteType.Express, "C3"),
                new(TheodorHeussPlatz, RouteType.Standard, "A2", "Theodor-Heuss-Platz"),
                new(Tierpark, RouteType.Standard, "E2"),
                new(TreptowerPark, RouteType.Express, "D3", "Treptower Park"),
                new(Turmstr, RouteType.Standard, "B2", "Turmstr."),
                new(WarschauerStr, RouteType.Express, "D3", "Warschauer Str."),
                new(Wedding, RouteType.Express, "B2"),
                new(Westhafen, RouteType.Express, "B2"),
                new(YorckStr, RouteType.Standard, "C3", "Yorckstr."),
                new(Zehlendorf, RouteType.Express, "A4"),
                new(Zeuthen, RouteType.Express, "E4"),
                new(Zitadelle, RouteType.Express, "A2"),
            });
        }
    }
}
