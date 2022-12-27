using System.Threading.Tasks;
using FluentAssertions;
using scg.Services;
using scg.Utils;
using Xunit;

namespace scg.UnitTest;

public class StringCypherTest : UnitTest
{
    [Fact]
    public void EncryptAndDecryptGiveSameString()
    {
        var encryptedText = StringCipher.Encrypt("SomeText", "ABC");

        var result = StringCipher.Decrypt(encryptedText, "ABC");

        result.Should().Be("SomeText");
    }

    [Fact]
    public async Task BggLogin()
    {
        var service = new BggApiService();
        await service.Login("MadMihi", "bggPwd25;");
    }
}