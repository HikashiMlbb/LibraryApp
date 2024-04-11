using LibraryApp.API.Extensions;
using LibraryApp.Application;
using LibraryApp.Infrastructure;
using LibraryApp.Infrastructure.Data;
using LibraryApp.Persistence;
using Microsoft.EntityFrameworkCore;

const string defaultPolicy = "AllowLocalhost";

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration, "SqlServer");
builder.Services.AddPersistence();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        defaultPolicy,
        policy => policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

#region Migrate before starting app

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryDatabaseContext>().Database;
    if (!db.CanConnect()) 
    {
        db.Migrate();
    }
}

#endregion

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseValidationExceptionHandler();
app.UseCors(defaultPolicy);
app.MapControllers();
app.Run();