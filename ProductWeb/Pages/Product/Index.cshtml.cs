using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductWeb.API;
using Prod = ProductWeb.Models.Product;

namespace ProductWeb.Pages.Product
{
  public class IndexModel : PageModel
  {
    private readonly IConnector _connector;

    public List<Prod> products { get; set; }

    public IndexModel(IConnector connector)
    {
      _connector = connector;
    }

    public async Task OnGetAsync()
    {
      products = await _connector.GetAllAsync();
    }
  }
}
