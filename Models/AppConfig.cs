
namespace Simplicator.Models;

public class AppConfig
{
    public string KeyVault { get; set; } = null!;
    public AzureAd AzureAd { get; set; } = null!;
}

public class AzureAd
{
    public string Instance { get; set; } = null!;
    public string ClientId { get; set; } = null!;
    public string ClientSecret { get; set; } = null!;
    public string TenantId { get; set; } = null!;

}
