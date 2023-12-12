using System;

namespace scg.Utils;

internal static class BggUtils
{
    public static string GetThreadFromLocation(string location)
    {
        // Location should look like this: https://boardgamegeek.com/thread/2527973/article/36118152#36118152
        var withoutThread = location.Replace("https://boardgamegeek.com/thread/", "");
        var index = withoutThread.IndexOf("/", StringComparison.InvariantCulture);
        return withoutThread.Substring(0, index);
    }
}