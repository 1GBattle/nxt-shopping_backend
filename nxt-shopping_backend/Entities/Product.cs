namespace nxt_shopping_backend.Entities
{
  public class Product
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public long Price { get; set; }
    public string PictureUrl { get; set; }
    public string ProductType { get; set; }
    public string Brand { get; set; }
    public int QuanityInStock { get; set; }
  }
}