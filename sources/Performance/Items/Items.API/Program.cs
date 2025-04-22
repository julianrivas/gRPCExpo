using Items.API.Configs;
using Items.Application;
using Items.Persistence;
using Mapster;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.AddKestrelConfig();

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddMapster();
builder.Services.AddControllers();
builder.Services.AddMasstransit();
builder.Services.AddGrpc();
builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment()) 
    app.UseSwaggerDevelopment();

app.UseEFCoreMigration();
app.MapControllers();
app.UseGrpc();
app.Run();