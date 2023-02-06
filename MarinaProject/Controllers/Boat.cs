using Microsoft.AspNetCore.Mvc;

namespace MarinaProject.Controllers
{
    public class Boat : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
