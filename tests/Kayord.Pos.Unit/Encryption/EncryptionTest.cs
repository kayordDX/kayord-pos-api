using Kayord.Pos.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Kayord.Pos.Unit.Encryption;

public class Tests(App app) : TestBase<App>
{
    [Fact]
    public void Sample_Test()
    {
        // app.CreateClient()
        (1 + 1).Should().Be(2);
    }

    [Theory]
    [InlineData("test")]
    [InlineData("longer string with spaces")]
    [InlineData("&%$#!$%$!@#")]
    [InlineData("00000000000")]
    public void Encrypt_Test(string plainText)
    {
        var encryptionService = app.Services.GetRequiredService<EncryptionService>();
        encryptionService.Should().NotBeNull();
        if (encryptionService == null)
        {
            return;
        }
        var iv = encryptionService.GenerateIV();
        iv.Should().NotBeNull();

        var encryptedValue = encryptionService.Encrypt(plainText, iv);
        var decryptedValue = encryptionService.Decrypt(encryptedValue, iv);
        decryptedValue.Should().Be(plainText);
    }

    [Fact]
    public void Encrypt_To()
    {
        string plainText = "test";
        var encryptionService = app.Services.GetRequiredService<EncryptionService>();
        encryptionService.Should().NotBeNull();
        if (encryptionService == null)
        {
            return;
        }
        // Create static byte array for IV generation
        var iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        // var iv = encryptionService.GenerateIV();
        iv.Should().NotBeNull();

        var encryptedValue = encryptionService.Encrypt(plainText, iv);
        // var decryptedValue = encryptionService.Decrypt(encryptedValue, iv);
        encryptedValue.Should().Be("QYpcRVMidIJlZXT10sQd8Q==");

        var decryptedValue = encryptionService.Decrypt(encryptedValue, iv);
        decryptedValue.Should().Be(plainText);
    }

    [Fact]
    public void Encrypt_Long()
    {
        string plainText = "KzI3ODQyNTAyMzExLmVhYzNhNTg3LTQ4NTUtNGY5YS1hNmMxLTNkMDA1NjM3OWVlYg==";
        var encryptionService = app.Services.GetRequiredService<EncryptionService>();
        encryptionService.Should().NotBeNull();
        if (encryptionService == null)
        {
            return;
        }
        // Create static byte array for IV generation
        var iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        // var iv = encryptionService.GenerateIV();
        iv.Should().NotBeNull();

        var encryptedValue = encryptionService.Encrypt(plainText, iv);
        // var decryptedValue = encryptionService.Decrypt(encryptedValue, iv);
        encryptedValue.Should().Be("oOldcF9k8xU1ccDMBmbK/+1ds4VD3wvr7Q32mtsCWAp5neQJJ38EBSXxxHwb2urgOHh8/qlzkxrYqLWRgPqhUAs7yaJShxGj0/ELCrRnT1Y=");

        var decryptedValue = encryptionService.Decrypt(encryptedValue, iv);
        decryptedValue.Should().Be(plainText);
    }
}