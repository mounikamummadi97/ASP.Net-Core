// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Xml.XPath;

public class program
{
    async static Task Main(string[] args)
    {
        string CLIENT_ID = "8f6bd982-92c3-4de0-985d-0e287c55e379";
        string BASE_URI = "https://mounikakv.vault.azure.net/";
        string CLIENT_SECRET = "ac781b325a4b4c40983fba301030546a";
        var client = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(async (string auth, string res, string scope) =>
        {
            var authContext = new AuthenticationContext(auth);
            var credential = new ClientCredential(CLIENT_ID, CLIENT_SECRET);
           AuthenticationResult RESULT = await authContext.AcquireTokenAsync(res, credential);
            if (RESULT == null)
            {
                throw new InvalidOperationException("Failed to  retrieve token");
            }
            return XPathResultType.AccessToken;
        }));
        var secretData = await client.GetSecretAsync(BASE_URI,"TestSecretKey");
        Console.WriteLine("Secret:" + secretData.Value);
        Console.ReadKey();
    }
}