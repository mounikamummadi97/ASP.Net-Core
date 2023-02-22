using Microsoft.EntityFrameworkCore;
using xUnitTesting_WebAPI.Data;
using xUnitTesting_WebAPI.DataManager;
using xUnitTesting_WebAPI.Interface;
using xUnitTesting_WebAPI.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("xUnitTesting")));
builder.Services.AddScoped<IDataRepository, CustomerDataManager>();
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
