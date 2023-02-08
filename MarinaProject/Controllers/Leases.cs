using Microsoft.AspNetCore.Mvc;

namespace MarinaProject.Controllers
{
    public class Leases : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
