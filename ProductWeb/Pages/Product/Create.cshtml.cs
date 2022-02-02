using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductWeb.API;
using Prod = ProductWeb.Models.Product;

namespace ProductWeb.Pages.Product
{
  public class CreateModel : PageModel
  {
    private readonly IConnector _connector;

    [BindProperty]
    public Prod Product { get; set; } = new();

    public CreateModel(IConnector connector)
    {
      _connector = connector;
    }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPostAsync()
    {
      await _connector.CreateAsync(Product);
      return RedirectToPage("/product/index");
    }
  }
}
