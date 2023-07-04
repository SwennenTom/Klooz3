using Microsoft.AspNetCore.Mvc;

namespace Klooz3.Controllers
{
    public class ExperimentenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
