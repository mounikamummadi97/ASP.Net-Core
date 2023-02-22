using Microsoft.EntityFrameworkCore;
using OneToMany_foreignKey_Relation.Data;
using OneToMany_foreignKey_Relation.DataManager;
using OneToMany_foreignKey_Relation.Model;
using static OneToMany_foreignKey_Relation.DataManager.IdataRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<API_DBContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDBs3")));
builder.Services.AddScoped<IDataRepository<Customer>, CustomerDataManager>();
builder.Services.AddScoped<IDataRepository<Product>, ProductDatamanager>();


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
