namespace ProductAPI.Data
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int Price { get; set; }

    public ProductType ProductType { get; set; }
  }
}

public enum ProductType
{
  CPU,
  MONITOR,
  PERIPHARALS,
  EXTERNAL
}