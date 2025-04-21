using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;

namespace CleanArchitecture.Infrastructure.Common;

public class OpenIdConfigurationService(HttpClient httpClient)
{
    public async Task<OpenIdConnectConfiguration> GetAsync(string openIdConnectConfiguration)
    {
        var configManager = new ConfigurationManager<OpenIdConnectConfiguration>
        (openIdConnectConfiguration,
        new OpenIdConnectConfigurationRetriever(),
        new HttpDocumentRetriever(httpClient) { RequireHttps = false });

        return await configManager.GetConfigurationAsync();
    }
}
