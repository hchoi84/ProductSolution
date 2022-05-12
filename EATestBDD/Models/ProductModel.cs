using System.ComponentModel.DataAnnotations;

namespace EATestBDD.Models
{
  public class ProductModel
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }

    public ProductTypeEnum ProductType { get; set; }
  }
}