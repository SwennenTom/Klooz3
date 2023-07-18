using Microsoft.AspNetCore.Mvc;

namespace Klooz3.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
