using Microsoft.AspNetCore.Mvc;

namespace Projekt.Intranet.Controllers
{
    public class LogowanieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
