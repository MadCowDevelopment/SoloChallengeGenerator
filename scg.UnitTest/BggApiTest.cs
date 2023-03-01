using System.Threading.Tasks;
using scg.Services;
using Xunit;

namespace scg.UnitTest;

public class BggApiTest
{
    [Fact]
    public async Task X()
    {
        var api = new BggApiService();

        await api.Login("", "");
        await api.PostGeeklistItem(249689, 265736, "No nonsense from C#");
    }
}