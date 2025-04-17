using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projekt.Intranet.Models;

namespace Projekt.Intranet.Controllers;

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
    public IActionResult Rezerwacje()
    {
        return View();
    }
    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Pracownicy()
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
