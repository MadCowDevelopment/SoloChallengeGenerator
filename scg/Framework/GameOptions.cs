using System.Collections.Generic;

namespace scg.Framework
{
    public class GameOptions
    {
        public Dictionary<string, string> Options { get; } = new Dictionary<string, string>();

        public void Initialize(string gameId)
        {
            if (gameId == "OnTheUnderground")
            {
                Options.Add("Map", "Berlin"); // TODO: Randomize
            }
        }
    }
}
