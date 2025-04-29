using Bitacoras.API.Configs;
using Bitacoras.Application;
using Bitacoras.Persistence;

var builder = WebApplication
    .CreateBuilder(args);

builder.WebHost
    .AddKestrelConfig();

builder.Services
    .AddApplication()
    .AddPersistence(builder.Configuration)
    .AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwaggerDevelopment();

app.UseHttpsRedirection();
app.UseEFCoreMigration();
app.MapControllers();
app.UseGrpc();
app.Run();