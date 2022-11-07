using Azure.Security.KeyVault.Secrets;
using Simplicator.Models;

namespace Simplicator.Services;

public interface IKeyVaultService
{
    public IEnumerable<SecretProperties> GetSecretProperties(string name);
    public Task<KeyVaultSecret> GetSecret(string name);

}

public class KeyVaultService : IKeyVaultService
{
    private readonly SecretClient _secretClient;
    
    private readonly HttpClient _client;
    
    public KeyVaultService(
        SecretClient secretClient, HttpClient client)
    {
        _secretClient = secretClient;
        _client = client;
    }

    public async Task<KeyVaultSecret> GetSecret(string name)
    {
        return await this._secretClient.GetSecretAsync(name);
    }

    public IEnumerable<SecretProperties> GetSecretProperties(string name)
    {
        var items = this._secretClient.GetPropertiesOfSecrets();

        return items.Where(r => r.Name.StartsWith(name));
    }


    public async Task<UserClaim> GetUser()
    {
        var items = await this._client.GetFromJsonAsync<IEnumerable<UserClaim>>("/.auth/me");

        if (items != null && items.Count() > 0)
        {
            return items.First();
        }

        throw new UnauthorizedAccessException();

    }

}