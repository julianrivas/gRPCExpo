using Items.API.Configs;
using Items.Application;
using Items.Persistence;
using Items.Persistence.Context.Configs;
using Items.Persistence.Context;
using Mapster;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration
    .GetConnectionString("DatabaseConnection");

builder.Services.AddApplication();
builder.Services.AddPersistence(connectionString);

builder.Services.AddMapster();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment()) 
    app.UseSwaggerDevelopment();

app.Services.UseStartupMigration<ItemsContext>();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();