using DossierAPI.Data;
using DossierAPI.IRepositories;
using DossierAPI.Repositories;
using DossierAPI.Services;
using DossierAPI.IRepositories;
using DossierAPI.Repositories;
using DossierAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DossierDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITypeVoyageRepository, TypeVoyageRepository>();
builder.Services.AddScoped<ITypeVoyageService, TypeVoyageService>();

builder.Services.AddScoped<IDossierRepository, DossierRepository>();
builder.Services.AddScoped<IDossierService, DossierService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
