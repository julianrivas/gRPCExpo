using Clients.API.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMasstransitConfiguration();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();