using Klooz3.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Klooz3.Controllers
{
    public class AdministratieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly EmailService _emailService;

        public AdministratieController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SendEmail()
        {
            string toEmail = "tswennen@gmail.com";
            string subject = "Test Email";
            string body = "Dit is een test email.";

            await _emailService.SendEmailAsync(toEmail, subject, body);

            return RedirectToAction("Index");
        }
    }
}
