using System.Net.Http;
using System.Threading.Tasks;
using scg.Services;
using Xunit;

namespace scg.UnitTest;

public class BggApiTest
{
    [Fact]
    public async Task X()
    {
        var api = new BggApiService(new HttpClient());

        var link = await api.GetLinkToLastPageOfList(GlobalIdentifiers.GeekListId);
        Assert.Equal("xyz", link);
    }
}