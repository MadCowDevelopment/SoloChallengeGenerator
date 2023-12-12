using System.Globalization;

namespace scg.Utils;

public static class CultureInitializer
{
    private static bool _initialized;

    public static void Initialize()
    {
        if(_initialized) return;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
        _initialized = true;
    }
}