using nxt_shopping_backend.Data;
using nxt_shopping_backend.Entities;

namespace ProductRoutes
{
  public static class ProductEndpoints
  {
    public static void Map(WebApplication app, StoreContext context)
    {
      app.MapGet("/api/products", () => context.Products.ToList()).WithName("Get All Products").WithOpenApi();

      app.MapGet("/api/products/{id}", (int Id) => context.Products.Find(Id) is Product product ? Results.Ok(product) : Results.NotFound())
      .WithName("Get Single Product").WithOpenApi();
    }
  }
}