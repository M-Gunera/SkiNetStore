using API.Errors;
using API.Extensions;
using API.Middleware;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAplicationServices(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migrations");

}

app.Run();
