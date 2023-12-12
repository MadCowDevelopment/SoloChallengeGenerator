using scg.Utils;

namespace scg.UnitTest;

public abstract class UnitTest
{
    protected UnitTest()
    {
        CultureInitializer.Initialize();
    }
}