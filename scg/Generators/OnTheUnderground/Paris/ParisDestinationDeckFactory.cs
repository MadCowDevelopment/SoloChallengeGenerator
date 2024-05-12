using System.Collections.Generic;
using static scg.Generators.OnTheUnderground.Paris.ParisLocation;

namespace scg.Generators.OnTheUnderground.Paris;

public class ParisDestinationDeckFactory : IDestinationDeckFactory
{
    public DestinationDeck Create()
    {
        return new("Paris", new List<DestinationCard>
        {
            new(MargadetPoissonniers, "C1", "Margadet Poissonniers"),
            new(Pigalle, "C1"),
            new(BarbesRochechouart, "C1", "Barbes Rochechouart"),
            new(Stalingrad, "D1"),
            new(Jaures, "D1"),
            new(PlaceDeClichy, "B2", "Place De Clichy"),
            new(Villiers, "B2"),
            new(Liege, "B2"),
            new(ChausseeDAntinLaFayette, "C2", "Chaussee D'Antin - La Fayette"),
            new(RichelieuDrouot, "C2", "Richelieu Drouot"),
            new(StrasbourgSaintDenis, "C2", "Strasbourg Saint-Denis"),
            new(ReaumurSebastopol, "C2", "Reaumur Sebastopol"),
            new(ArtsEtMetiers, "C2", "Arts et Metiers"),
            new(BelleVille, "D2"),
            new(Oberkampf, "D2"),
            new(PereLachaise, "D2", "Pere Laghaise"),
            new(Trogadero, "A3"),
            new(FranklinDRoosevelt, "B3", "Franklin D. Roosevelt"),
            new(Miromesnil, "B3"),
            new(Madeleine, "B3"),
            new(ChampsElyseesClemenceau, "B3", "Champs Elysees - Clemenceau"),
            new(Concorde, "B3"),
            new(LaMottePicquetGrenelle, "B3", "La Motte Picquet - Grenelle"),
            new(Duroc, "B3"),
            new(Pyramides, "C3"),
            new(PalaisRoyalMuseeDuLouvre, "C3", "Palais Royal - Musee Du Louvre"),
            new(HotelDeVille, "C3", "Hotel De Ville"),
            new(Odeon, "C3"),
            new(Jussieu, "C3"),
            new(SaintPlacide, "C3", "Saint-Placide"),
            new(Bastille, "D3"),
            new(ReuillyDiderot, "D3", "Reuilly - Diderot"),
            new(Bergy, "D3"),
            new(Daumesnil, "E3"),
            new(MichelAnge, "A4", "Michel-Ange"),
            new(Pasteur, "B4"),
            new(PlaceDItalie, "D4", "Place D'Italie")
        });
    }
}
