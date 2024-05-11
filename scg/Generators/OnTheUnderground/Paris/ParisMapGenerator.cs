using System;
using System.Collections.Generic;
using scg.Framework;
using scg.Utils;
using Svg;
using static scg.Generators.OnTheUnderground.Paris.ParisLocation;

namespace scg.Generators.OnTheUnderground.Paris;

public class ParisMapGenerator : MapGenerator<ParisLine, ParisLocation>
{
    public ParisMapGenerator(GlobalRepository globalRepository) : base(globalRepository)
    {
    }

    protected override void InitializeLandmarks(SvgDocument doc)
    {
        var landmarkLocations = new List<ParisLocation>
        {
            MairieDeSaintOuen, LamarckCaulaincourt, MarxDormoy, Crimee, Ourcq, EgliseDePantin, LaFourche,
            NotreDameDeLorette, Poissonniere, LouisBlanc, PlaceDesFetes, PorteDesLilas, Parmentier,
            Couronnes, Gambetta, PorteMaillot, Monceau, SaintSebastienFroissart, EtienneMarcel,
            Rambuteau, CheminVert, BreguetSabin, SaintMande, LedruRollin, Liberte, Jasmin, CharlesMichels,
            CensierDaubenton, CampoFormio, QuaiDeLaGare, CourSaintEmilion, CharentonEcoles, Boucicaut,
            SevresLecourbe, Glaciere, MarcelSembat, PorteDeVersailles, Plaisance, MaisonBlanche, PorteDeChoisy
        };

        landmarkLocations.Shuffle();

        for (var i = 0; i < landmarkLocations.Count; i++)
        {
            var landmarkIcon = doc.GetElementById<SvgImage>($"Landmark{i + 1}");
            landmarkIcon.X = new SvgUnit(GetCanvasLeft(landmarkLocations[i]));
            landmarkIcon.Y = new SvgUnit(GetCanvasTop(landmarkLocations[i]));
        }
    }

    protected override string SvgFilename { get; } = "Map_Paris.svg";

    private float GetCanvasLeft(ParisLocation landmarkLocation)
    {
        return landmarkLocation switch
        {
            MairieDeSaintOuen => 150,
            LamarckCaulaincourt => 180.2f,
            MarxDormoy => 238.9f,
            Crimee => 297.5f,
            Ourcq => 327.3f,
            EgliseDePantin => 357.1f,
            LaFourche => 150.5f,
            NotreDameDeLorette => 179.9f,
            Poissonniere => 209.5f,
            LouisBlanc => 267.9f,
            PlaceDesFetes => 327.3f,
            PorteDesLilas => 357.3f,
            Parmentier => 297.2f,
            Couronnes => 327.2f,
            Gambetta => 357.2f,
            PorteMaillot => 31.4f,
            Monceau => 90.7f,
            SaintSebastienFroissart => 267.5f,
            EtienneMarcel => 209.6f,
            Rambuteau => 238.6f,
            CheminVert => 267.9f,
            BreguetSabin => 297.4f,
            SaintMande => 357.5f,
            LedruRollin => 297.4f,
            Liberte => 357.2f,
            Jasmin => 31.6f,
            CharlesMichels => 60.7f,
            CensierDaubenton => 238.4f,
            CampoFormio => 268.0f,
            QuaiDeLaGare => 297.6f,
            CourSaintEmilion => 357.1f,
            CharentonEcoles => 386.5f,
            Boucicaut => 90.4f,
            SevresLecourbe => 119.8f,
            Glaciere => 238.7f,
            MarcelSembat => 60.7f,
            PorteDeVersailles => 119.8f,
            Plaisance => 179.5f,
            MaisonBlanche => 268.4f,
            PorteDeChoisy => 297.8f,
            _ => throw new InvalidOperationException($"The location '{landmarkLocation}' is not valid for a landmark.")
        };
    }

    private float GetCanvasTop(ParisLocation landmarkLocation)
    {
        return landmarkLocation switch
        {
            MairieDeSaintOuen => 46.8f,
            LamarckCaulaincourt => 46.8f,
            MarxDormoy => 47.0f,
            Crimee => 46.3f,
            Ourcq => 46.4f,
            EgliseDePantin => 25.9f,
            LaFourche => 66.9f,
            NotreDameDeLorette => 88.0f,
            Poissonniere => 88.3f,
            LouisBlanc => 88.2f,
            PlaceDesFetes => 87.5f,
            PorteDesLilas => 87.5f,
            Parmentier => 108.3f,
            Couronnes => 108.3f,
            Gambetta => 108.3f,
            PorteMaillot => 128.7f,
            Monceau => 128.4f,
            SaintSebastienFroissart => 128.6f,
            EtienneMarcel => 149.1f,
            Rambuteau => 149.1f,
            CheminVert => 149.1f,
            BreguetSabin => 149.2f,
            SaintMande => 149.2f,
            LedruRollin => 169.8f,
            Liberte => 190.9f,
            Jasmin => 211.0f,
            CharlesMichels => 211.0f,
            CensierDaubenton => 210.4f,
            CampoFormio => 210.8f,
            QuaiDeLaGare => 211.2f,
            CourSaintEmilion => 211.4f,
            CharentonEcoles => 211.5f,
            Boucicaut => 231.6f,
            SevresLecourbe => 231.9f,
            Glaciere => 231.3f,
            MarcelSembat => 252.5f,
            PorteDeVersailles => 252.5f,
            Plaisance => 252.3f,
            MaisonBlanche => 252.5f,
            PorteDeChoisy => 252.7f,
            _ => throw new InvalidOperationException($"The location '{landmarkLocation}' is not valid for a landmark.")
        };
    }
}