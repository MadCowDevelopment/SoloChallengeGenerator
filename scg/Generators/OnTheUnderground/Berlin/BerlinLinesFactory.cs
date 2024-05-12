using System.Collections.Generic;
using System.Collections.ObjectModel;
using static scg.Generators.OnTheUnderground.Berlin.BerlinLocation;

namespace scg.Generators.OnTheUnderground.Berlin;
public static class BerlinLinesFactory
{
    public static IReadOnlyCollection<BerlinLine> Create()
    {
        return new ReadOnlyCollection<BerlinLine>(
            new List<BerlinLine>
            {
                new BerlinLine(1, "S1", 20, BerlinLineIcon.Circle,
                    new List<BerlinLocation>
                    {
                        Oranienburg, Birkenwerder, Wittenau, BornholmerStr, Gesundbrunnen, Friedrichstr,
                        PotsdamerPlatz, Moeckernbruecke, YorckStr, Schoeneberg, RathausSteglitz,
                        BotanischerGarten, Zehlendorf, KrummeLanke, Wannsee, PotsdamHbf
                    }),
                new BerlinLine(2, "S2/S25/S26", 20, BerlinLineIcon.Circle,
                    new List<BerlinLocation>
                    {
                        Henningsdorf, AltTegel, KarlBonhoefferNervenklinik, Wittenau, BornholmerStr,
                        Gesundbrunnen, Friedrichstr, PotsdamerPlatz, Moeckernbruecke, YorckStr,
                        Suedkreuz, Priesterweg, Marienfelde, Blankenfelde, BornholmerStr, Pankow,
                        Karow, Bernau, Priesterweg, LichterfeldeOst, TeltowStadt
                    }),

                new BerlinLine(3, "S3/S9", 15, BerlinLineIcon.Square,
                    new List<BerlinLocation>
                    {
                        Spandau, Olympiastadion, MesseSued, Westkreuz, Charlottenburg, ZoologischerGarten,
                        Hauptbahnhof, Friedrichstr, Alexanderplatz, Ostbahnhof, WarschauerStr, TreptowerPark,
                        SchoeneWeide, Adlershof, Gruenbergallee, FlughafenBerlinSchoenefeld,
                        WarschauerStr, Ostkreuz, Karlshorst, Koepenick, Erkner
                    }),
                new BerlinLine(4, "S7/S75", 15, BerlinLineIcon.Square,
                    new List<BerlinLocation>
                    {
                        PotsdamHbf, Wannsee, Grunewald, MesseSued, Westkreuz, Charlottenburg, ZoologischerGarten,
                        Hauptbahnhof, Friedrichstr, Alexanderplatz, Ostbahnhof, WarschauerStr, Ostkreuz,
                        Lichtenberg, FriedrichsfeldeOst, Springpfuhl, Hohenschoenhausen, Wartenberg,
                        Springpfuhl, Marzahn, Ahrensfelde
                    }),
                new BerlinLine(5, "S8/S85", 20, BerlinLineIcon.None,
                    new List<BerlinLocation>
                    {
                        Bergfelde, Schoenfliess, MuehlenbeckMoenchMuehle, Karow, Pankow, BornholmerStr,
                        SchoenhauserAllee, PrenzlauerAllee, Greifswalderstr, LandsbergerAllee, FrankfurterAllee,
                        Ostkreuz, TreptowerPark, SchoeneWeide, Adlershof, Zeuthen
                    }),
                new BerlinLine(6, "S41/S42", 10, BerlinLineIcon.Triangle,
                    new List<BerlinLocation>
                    {
                        Westend, Jungfernheide, Westhafen, Wedding, Gesundbrunnen, SchoenhauserAllee,
                        PrenzlauerAllee, Greifswalderstr, LandsbergerAllee, FrankfurterAllee, Ostkreuz,
                        TreptowerPark, Neukoelln, HermannStr, Tempelhof, Suedkreuz, Schoeneberg,
                        Bundesplatz, HeidelbergerPlatz, HohenzollernDamm, Westkreuz
                    }),
                new BerlinLine(7, "S45/S46/S47", 15, BerlinLineIcon.Triangle,
                    new List<BerlinLocation>
                    {
                        Westend, MesseNord, Westkreuz, HohenzollernDamm, HeidelbergerPlatz, Bundesplatz,
                        Schoeneberg, Suedkreuz, Tempelhof, HermannStr, Neukoelln, KoellnischeHeide,
                        SchoeneWeide, Spindlersfeld, SchoeneWeide, Adlershof, Zeuthen, KoenigsWusterhausen,
                        Adlershof, Gruenbergallee, FlughafenBerlinSchoenefeld
                    }),
                new BerlinLine(8, "U2", 25, BerlinLineIcon.None,
                    new List<BerlinLocation>
                    {
                        Ruhleben, TheodorHeussPlatz, MesseNord, BismarckStr, ZoologischerGarten,
                        Nollendorfplatz, PotsdamerPlatz, Stadtmitte, Alexanderplatz, SchoenhauserAllee,
                        Pankow
                    }),
                new BerlinLine(9, "U3/U6", 20, BerlinLineIcon.None,
                    new List<BerlinLocation>
                    {
                        AltTegel, Leopoldplatz, Wedding, Friedrichstr, Stadtmitte, HalleschesTor,
                        Mehringdamm, Tempelhof, HalleschesTor, KottbusserTor, WarschauerStr,
                        HalleschesTor, Moeckernbruecke, Nollendorfplatz, FehrbellinerPlatz, HeidelbergerPlatz,
                        DahlemDorf, KrummeLanke
                    }),
                new BerlinLine(10, "U5/U8", 20, BerlinLineIcon.None,
                    new List<BerlinLocation>
                    {
                        Wittenau, KarlBonhoefferNervenklinik, OsloerStr, Gesundbrunnen, Alexanderplatz,
                        StrausbergerPlatz, SamariterStr, FrankfurterAllee, Lichtenberg, Tierpark,
                        Wuhletal, Hoenow, Alexanderplatz, Ostbahnhof, KottbusserTor, Hermannplatz,
                        HermannStr
                    }),
                new BerlinLine(11, "U7", 20, BerlinLineIcon.None,
                    new List<BerlinLocation>
                    {
                        Spandau, Zitadelle, PaulSternStr, Siemensdamm, Jungfernheide, Mierendorffplatz,
                        BismarckStr, Charlottenburg, FehrbellinerPlatz, BayerischerPlatz, YorckStr,
                        Moeckernbruecke, Mehringdamm, Hermannplatz, Neukoelln, JohannisthalerChaussee
                    }),
            });
    }
}