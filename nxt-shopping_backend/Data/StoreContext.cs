using Microsoft.EntityFrameworkCore;
using nxt_shopping_backend.Entities;

namespace nxt_shopping_backend.Data
{
  public class StoreContext : DbContext
  {
    public StoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
  }
}