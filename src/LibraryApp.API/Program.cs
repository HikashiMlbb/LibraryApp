using Carter;
using LibraryApp.API.Extensions;
using LibraryApp.Application;
using LibraryApp.Infrastructure;
using LibraryApp.Infrastructure.Data;
using LibraryApp.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPersistence();

builder.Services.AddCarter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

#region Migrate before starting app

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<LibraryDatabaseContext>().Database.Migrate();
}

#endregion

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseValidationExceptionHandler();
app.MapCarter();
app.MapControllers();
app.Run();