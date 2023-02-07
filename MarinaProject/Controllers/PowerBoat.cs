using Microsoft.AspNetCore.Mvc;

namespace MarinaProject.Controllers
{
    public class PowerBoat : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
