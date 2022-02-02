using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductWeb.API;
using Prod = ProductWeb.Models.Product;

namespace ProductWeb.Pages.Product
{
  public class DetailModel : PageModel
  {
    private readonly IConnector _connector;

    public Prod Product { get; set; } = new();

    public DetailModel(IConnector connector)
    {
      _connector = connector;
    }

    public async Task OnGetAsync(int id)
    {
      Product = await _connector.GetByIdAsync(id);
    }
  }
}
