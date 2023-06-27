using Microsoft.AspNetCore.Mvc;

namespace Klooz3.Controllers
{
    public class OverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
