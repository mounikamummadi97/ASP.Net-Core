using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using BAL.DataRepository;
using DAL.Data;
using DAL.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.KeyVault;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Microsoft.Web.Administration;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
var keyVaultEndPoint = new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/");//https://mounikakv.vault.azure.net/
object value = builder.Configuration.AddAzureKeyVault(keyVaultEndPoint, new DefaultAzureCredential());
builder.Services.AddDbContext<API_DBContext>(opts => opts.UseSqlServer(builder.Configuration["AzureDBConnString"]));

builder.Services.AddScoped<IDataRepository<Customer>, CustomerDataManager>();
builder.Services.AddScoped<IDataRepository1<Customer>, CustomerDataManager>();
builder.Services.AddScoped<IDataRepository2<Customer>, NewCustomerManager>();
builder.Services.AddScoped<IDataRepository<Product>, ProductDataManager>();
builder.Services.AddScoped<IDataRepository1<Product>, ProductDataManager>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "MSAL_Authdemo",
        Version = "v1",
    }); c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            Implicit = new OpenApiOAuthFlow()
            {

                AuthorizationUrl = new Uri("https://login.microsoftonline.com/8f6bd982-92c3-4de0-985d-0e287c55e379/oauth2/v2.0/authorize"),
                TokenUrl = new Uri("https://login.microsoftonline.com/8f6bd982-92c3-4de0-985d-0e287c55e379/oauth2/v2.0/token"),//Azure endpoints
                Scopes = new Dictionary<string, string>
                {
                        {
                            "api://1c65d9d7-eb40-4cad-8b23-bd94224204ad/Mounika",//scope
                            "User.Read"
                        }
                }
            }
        }
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                    Type = ReferenceType.SecurityScheme,
                        Id = "oauth2"
            },
                Scheme = "oauth2",
                Name = "oauth2",
                In = ParameterLocation.Header
        },
        new List < string > ()
    }});

});

var app = builder.Build();


//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    //string secretClientId = "OAuthClientId";
    //    string secretClientSecret = "OAuthClientSecret";
    //    string keyVaultName = "MounikaKeyVaultNew";
    //    var kvUri = "https://mounikakeyvaultnew.vault.azure.net/"; 

    //SecretClientOptions options = new SecretClientOptions() {
    //    Retry = { 
    //        Delay = TimeSpan.FromSeconds(2), 
    //        MaxDelay = TimeSpan.FromSeconds(16),
    //        MaxRetries = 5,
    //        Mode = RetryMode.Exponential 
    //    } }; 
    //var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential(), options);
    //KeyVaultSecret secret = client.GetSecret(secretClientId);
    //KeyVaultSecret secret1 = client.GetSecret(secretClientSecret);


    
    app.UseSwagger();
    //string secretClientId = "OAuthClientId";
    //string secretClientSecret = "OAuthClientSecret";
    //string keyVaultName = "MounikaKeyVaultNew";
    //var kvUri = "https://mounikakeyvaultnew.vault.azure.net/";

    //var client = new SecretClient(vaultUri: new Uri(kvUri), credential: new DefaultAzureCredential());

    //KeyVaultSecret secret1 = await client.GetSecretAsync(secretClientId);

    //KeyVaultSecret secret2 = await client.GetSecretAsync(secretClientSecret);

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthDemo v1");

        //c.OAuthClientId(secret1.Value);

        //c.OAuthClientSecret(secret2.Value);

        c.OAuthClientId("1c65d9d7-eb40-4cad-8b23-bd94224204ad");
        c.OAuthClientSecret("2R~8Q~kLYJVVzZqpMHVD0bal3bBq_r3roQEdncGy");

        c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
