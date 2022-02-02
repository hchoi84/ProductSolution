using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductWeb.API;
using Prod = ProductWeb.Models.Product;

namespace ProductWeb.Pages.Product
{
  public class EditModel : PageModel
  {
    private readonly IConnector _connector;

    [BindProperty]
    public Prod Product { get; set; } = new();

    public EditModel(IConnector connector)
    {
      _connector = connector;
    }

    public async Task OnGetAsync(int id)
    {
      Product = await _connector.GetByIdAsync(id);
    }

    public async Task<IActionResult> OnPostAsync()
    {
      await _connector.UpdateAsync(Product);
      return RedirectToPage("/product/index");
    }
  }
}
