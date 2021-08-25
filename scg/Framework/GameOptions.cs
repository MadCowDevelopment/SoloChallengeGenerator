using System;
using System.Collections.Generic;
using scg.Utils;

namespace scg.Framework
{
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
                var mapName = (_endDateHelper.GetEndDate(1).Month % 2) switch
                {
                    0 => "Berlin",
                    1 => "London",
                    _ => throw new InvalidOperationException("Cannot determine map name.")
                };

                Options.Add("Map", mapName);
            }
        }
    }
}