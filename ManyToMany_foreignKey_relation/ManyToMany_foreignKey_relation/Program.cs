using ManyToMany_foreignKey_relation.Data;
using ManyToMany_foreignKey_relation.DataManager;
using ManyToMany_foreignKey_relation.IDataRepository;
using ManyToMany_foreignKey_relation.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDBs2")));
builder.Services.AddScoped<IDataRepository<Customer>, CustomerDataManager>();
builder.Services.AddScoped<IDataRepository<Product>, ProductDataManager>();
builder.Services.AddScoped<IDataRepository<CustomerProduct>, CustomerProductDataManager>();
builder.Services.AddControllers();

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
