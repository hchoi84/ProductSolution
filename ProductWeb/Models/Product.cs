using System.ComponentModel.DataAnnotations;

namespace ProductWeb.Models
{
  public class Product
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int Price { get; set; }

    public ProductType ProductType { get; set; }
  }
}
