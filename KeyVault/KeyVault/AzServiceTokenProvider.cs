using Azure.Core;
using Azure.Identity;

namespace KeyVault
{
    public class AzServiceTokenProvider
    {
        private static AccessToken _accessToken;
        public static string GetAccessToken(IConfiguration _configuration) 
        {
            var tokenCredential = new DefaultAzureCredential();
            _accessToken = tokenCredential.GetToken(
                new TokenRequestContext(scopes: new string[] { "http://database.windows.net" }, null, null, _configuration["Mounika"]));
            return _accessToken.Token;
        }
    }
}
