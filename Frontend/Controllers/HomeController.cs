using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Frontend.ViewModels;
using Frontend.Services;

namespace Frontend.Controllers;

public class HomeController(IProductService productService) : Controller
{
    public async Task<IActionResult> Index() => View(await productService.FindAllProducts());
    public async Task<IActionResult> ProductDetails(long id) => View(await productService.FindProductById(id));
    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
