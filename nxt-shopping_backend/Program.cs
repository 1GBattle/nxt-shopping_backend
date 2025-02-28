using Microsoft.EntityFrameworkCore;
using nxt_shopping_backend.Data;
using ProductRoutes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(opts =>
{
  opts.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//   var forecast = Enumerable.Range(1, 5).Select(index =>
//       new WeatherForecast
//       (
//           DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//           Random.Shared.Next(-20, 55),
//           summaries[Random.Shared.Next(summaries.Length)]
//       ))
//       .ToArray();
//   return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
ProductEndpoints.Map(app, context);

try
{
  context.Database.Migrate();
  DbInitializer.Initialize(context);
}
catch (Exception ex)
{
  logger.LogError(ex, "A problem occured during migration");
  throw;
}
app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string Summary)
// {
//   public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
