using Microsoft.Data.SqlClient;
using Poudlard.Api.Domain.Repositories;
using Poudlard.Api.Domain.Services;

using Scalar.AspNetCore;
using System.Data.Common;

string policyName = "CorsicanPoliceDepartment";

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(c => c.AddPolicy(policyName, o =>
{
    o.WithOrigins("https://localhost:7209").AllowAnyMethod().AllowAnyHeader();
}));


builder.Services.AddScoped<IMaisonRepository, MaisonService>();
builder.Services.AddScoped<ISorcierRepository, SorcierService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //Pour Ajouter Scalar
    // 1. Ajouter le package Nuget Scalar.AspNetCore
    // 2. ajouter 'using Scalar.AspNetCore;' en entête du fichier Progam.cs
    // 3. Ajouter 'app.MapScalarApiReference();' ci-dessous
    // 4. Changer l'url de "launchUrl" dans le fichier launchSettings.json
    app.MapScalarApiReference();
}

app.UseCors(policyName);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
