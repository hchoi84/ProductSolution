using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Data
{
  public class ProductModel
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int Price { get; set; }

    public ProductTypeEnum ProductType { get; set; }
  }
}