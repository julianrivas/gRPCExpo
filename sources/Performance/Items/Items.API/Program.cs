using Items.API.Configs;
using Items.Application;
using Items.Persistence;

var builder = WebApplication
    .CreateBuilder(args);

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
app.Run();