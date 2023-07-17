using Microsoft.AspNetCore.Mvc;

namespace Klooz3.Controllers
{
    public class AdministratieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
