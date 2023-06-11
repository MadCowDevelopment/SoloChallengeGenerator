using FluentAssertions;
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
}