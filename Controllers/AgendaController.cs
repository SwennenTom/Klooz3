using Microsoft.AspNetCore.Mvc;

namespace Klooz3.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
