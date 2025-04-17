using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projekt.PortalWWW.Models;

namespace Projekt.PortalWWW.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Zaloga()
    {
        return View();
    }

    public IActionResult Sklep()
    {
        return View();
    }

    public IActionResult ONas()
    {
        return View();
    }
    public IActionResult Kontakt()
    {
        return View();
    }
    public IActionResult Koszyk()
    {
        return View();
    }
    public IActionResult Produkt()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
