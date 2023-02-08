using Microsoft.AspNetCore.Mvc;

namespace MarinaProject.Controllers
{
    public class Dock : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
