using Azure.Identity;
using KeyVault;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var keyVaultEndPoint =new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/");//https://mounikakv.vault.azure.net/
builder.Configuration.AddAzureKeyVault(keyVaultEndPoint, new DefaultAzureCredential());
builder.Services.AddDbContext<EmpDBContext>(opts => opts.UseSqlServer(builder.Configuration["AzureDBConnString"]));//keyVaultName
builder.Services.AddScoped<IEmployeeServive<Employee>, DataManger>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
