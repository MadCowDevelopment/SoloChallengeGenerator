using System.Collections.Generic;
using System.Collections.ObjectModel;
using static scg.Generators.OnTheUnderground.Paris.ParisLocation;

namespace scg.Generators.OnTheUnderground.Paris;

public static class ParisLinesFactory
{
    public static IReadOnlyCollection<ParisLine> Create()
    {
        return new ReadOnlyCollection<ParisLine>(
            new List<ParisLine>
            {
                new ParisLine(1, "8", 10,
                    new List<ParisLocation>
                    {
                       Balard, Boucicaut, LaMottePicquetGrenelle, Invalides, Concorde, Madeleine, Opera, RichelieuDrouot,
                       StrasbourgSaintDenis, Republique, SaintSebastienFroissart, CheminVert, Bastille, LedruRollin,
                       ReuillyDiderot, Daumesnil, Liberte, CharentonEcoles, CreteilPointeDuLac
                    }),
                new ParisLine(2, "2 11", 10,
                    new List<ParisLocation>
                    {
                        PorteDauphine, CharlesDeGaulleEtoile, Monceau, Villiers, PlaceDeClichy, Pigalle, BarbesRochechouart,
                        GareDuNord, Stalingrad, Jaures, BelleVille, PlaceDesFetes, PorteDesLilas, BelleVille, Republique, 
                        ArtsEtMetiers, Rambuteau, HotelDeVille, Chatelet, BelleVille, Couronnes, PereLachaise, Nation
                    }),
                new ParisLine(3, "5 10", 10,
                    new List<ParisLocation>
                    {
                        MichelAnge, CharlesMichels, LaMottePicquetGrenelle, Duroc, SevresBabylone, Odeon, SaintMichelNotreDame,
                        Jussieu, GareDAusterlitz, CampoFormio, PlaceDItalie, GareDAusterlitz, Bastille, BreguetSabin, Oberkampf,
                        Republique, GareDeLEst, LouisBlanc, Jaures, Ourcq, EgliseDePantin, BobignyPabloPicasso
                    }),
                new ParisLine(4, "7", 15,
                    new List<ParisLocation>
                    {
                        SaintLazare, Opera, ChausseeDAntinLaFayette, Poissonniere, GareDeLEst, LouisBlanc, Stalingrad, Crimee,
                        LaCourneuve8Mai1945, Opera, Pyramides, PalaisRoyalMuseeDuLouvre, Chatelet, HotelDeVille, Jussieu,
                        CensierDaubenton, PlaceDItalie, MaisonBlanche, VillejuifLouisAragon, MaisonBlanche, PorteDeChoisy, MairieDIvry
                    }),
                new ParisLine(5, "3 14", 15,
                    new List<ParisLocation>
                    {
                        PontDeLevalloisBegon, Pereire, Villiers, SaintLazare, Opera, ReaumurSebastopol, ArtsEtMetiers, Republique,
                        Parmentier, PereLachaise, Gambetta, Gallieni, SaintLazare, Madeleine, Pyramides, Chatelet, HotelDeVille,
                        GareDAusterlitz, GareDeLyon, Bergy, CourSaintEmilion, Olympiades
                    }),
                new ParisLine(6, "12", 15,
                    new List<ParisLocation>
                    {
                        MairieDIssy, PorteDeVersailles, Pasteur, MontparnasseBienvenue, SaintPlacide, SevresBabylone, Concorde,
                        Madeleine, SaintLazare, Liege, NotreDameDeLorette, Pigalle, LamarckCaulaincourt, MargadetPoissonniers,
                        MarxDormoy, FrontPopulaire
                    }),
                new ParisLine(7, "9", 15,
                    new List<ParisLocation>
                    {
                        PontDeSevres, MarcelSembat, MichelAnge, Jasmin, LaMuette, Trogadero, FranklinDRoosevelt, Miromesnil,
                        SaintLazare, ChausseeDAntinLaFayette, RichelieuDrouot, StrasbourgSaintDenis, Republique, Oberkampf,
                        Nation, MairieDeMontreuil
                    }),
                new ParisLine(8, "13", 20,
                    new List<ParisLocation>
                    {
                        LesCourtilles, PorteDeClichy, LaFourche, PlaceDeClichy, Liege, SaintLazare, Miromesnil, ChampsElyseesClemenceau,
                        Invalides, Duroc, Pasteur, MontparnasseBienvenue, Plaisance, ChatillonMontrouge, LaFourche,
                        MairieDeSaintOuen, SaintDenisUniversite
                    }),
                new ParisLine(9, "4", 20,
                    new List<ParisLocation>
                    {
                        PorteDeClicnancourt,  MargadetPoissonniers, BarbesRochechouart, GareDuNord, GareDeLEst, StrasbourgSaintDenis,
                        ReaumurSebastopol, EtienneMarcel, Chatelet, SaintMichelNotreDame, Odeon, SaintPlacide, MontparnasseBienvenue,
                        DenfertRochereau, MairieDeMontrouge
                    }),
                new ParisLine(10, "1", 20,
                    new List<ParisLocation>
                    {
                        LaDefense, PorteMaillot, CharlesDeGaulleEtoile, FranklinDRoosevelt, ChampsElyseesClemenceau, Concorde,
                        PalaisRoyalMuseeDuLouvre, Chatelet, HotelDeVille, Bastille, GareDeLyon, ReuillyDiderot, Nation,
                        SaintMande, ChateauDeVincennes
                    }),
                new ParisLine(11, "6", 20,
                    new List<ParisLocation>
                    {
                        CharlesDeGaulleEtoile, Trogadero, ChampDeMarsTourEiffel, LaMottePicquetGrenelle, SevresLecourbe, Pasteur,
                        MontparnasseBienvenue, DenfertRochereau, Glaciere, PlaceDItalie, QuaiDeLaGare, Bergy, Daumesnil, Nation
                    })
            });
    }
}
