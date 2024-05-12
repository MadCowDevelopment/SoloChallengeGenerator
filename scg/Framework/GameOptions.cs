using System;
using System.Collections.Generic;
using scg.Utils;

namespace scg.Framework;

public class GameOptions
{
    private readonly EndDateHelper _endDateHelper;

    public GameOptions(EndDateHelper endDateHelper)
    {
        _endDateHelper = endDateHelper;
    }

    public Dictionary<string, string> Options { get; } = new();

    public string Id => Options["Id"];

    public void Initialize(string gameId)
    {
        Options.Add("Id", gameId);

        if (gameId == "OnTheUnderground")
        {
            var enddate = _endDateHelper.GetEndDate(1);
            if (enddate.Year == 2024)
            {
                if (enddate.Month == 5 || enddate.Month == 7 || enddate.Month == 9) 
                {
                    Options.Add("Map", "Paris");
                    return;
                }
                else if(enddate.Month == 6 || enddate.Month == 8 || enddate.Month == 10)
                {
                    Options.Add("Map", "NewYork");
                    return;
                }
            }

            var mapName = (_endDateHelper.GetEndDate(1).Month % 4) switch
            {
                0 => "Berlin",
                1 => "Paris",
                2 => "NewYork",
                3 => "London",
                _ => throw new InvalidOperationException("Cannot determine map name.")
            };

            Options.Add("Map", mapName);
        }
        else if (gameId == "CartographersMaps")
        {
            Options.Add("ExploreCards", RNG.Between(0, 1) == 0 ? "Base" : "Heroes");
            Options.Add("IncludeHeroes", RNG.Bool().ToString());
        }
    }
}