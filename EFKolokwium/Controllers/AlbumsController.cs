using Microsoft.AspNetCore.Mvc;

namespace EFKolokwium.Controllers
{
    public class AlbumsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}