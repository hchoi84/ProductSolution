using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductWeb.API;
using Prod = ProductWeb.Models.Product;

namespace ProductWeb.Pages.Product
{
  public class DeleteModel : PageModel
  {
    private readonly IConnector _connector;

    public Prod Product { get; set; } = new();

    public DeleteModel(IConnector connector)
    {
      _connector = connector;
    }

    public async Task OnGet(int id)
    {
      Product = await _connector.GetByIdAsync(id);
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
      await _connector.DeleteByIdAsync(id);
      return RedirectToPage("Index");
    }
  }
}
