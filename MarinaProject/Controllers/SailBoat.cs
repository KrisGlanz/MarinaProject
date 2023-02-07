using Microsoft.AspNetCore.Mvc;

namespace MarinaProject.Controllers
{
    public class SailBoat : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
