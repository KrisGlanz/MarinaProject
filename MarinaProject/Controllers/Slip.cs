using Microsoft.AspNetCore.Mvc;

namespace MarinaProject.Controllers
{
    public class Slip : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
