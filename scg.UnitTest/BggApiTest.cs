using System.Threading.Tasks;
using Newtonsoft.Json;
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
        await api.PostGeeklistItem(249689, 265736, @"[b]Challenge Start:[/b] Now
[b]Challenge End:[/b] 03/31/2023

[b]Description:[/b]
Randomized objectives, buildings and specialists.

[b]Details found here:[/b]
[thread=$THREAD_ID$][/thread]");
    }
}