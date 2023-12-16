using NoiseMeterLib;  // Husk at importere det korrekte namespace for din st�jm�lerklasse
using RESTnoise.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<NoiseMeterRepository>(new NoiseMeterRepository()); // Tilf�j singleton-tjenesten

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

builder.WebHost.UseUrls("http://localhost");

app.Run();
