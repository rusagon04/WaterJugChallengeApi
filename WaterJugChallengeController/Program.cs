using WaterJugChallenge.Application.WaterJugChallenge.Models;
using WaterJugChallenge.Application.WaterJugChallenge.Services;
using WaterJugChallenge.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cache

builder.Services.AddMemoryCache();

// Services

builder.Services.AddScoped<IWaterJugChallengeService, WaterJugChallengeService>();

// Cache

builder.Services.AddScoped<IContextCache<WaterJugChallengeDTO>, ContextCache<WaterJugChallengeDTO>>();

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
