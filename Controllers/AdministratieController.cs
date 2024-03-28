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

        [Authorize(Roles = "Admin, TeamRegie")]
        public async Task<IActionResult> SendEmail(string InviteEmail)
        {
            //var urlHelper = HttpContext.RequestServices.GetRequiredService<IUrlHelper>();
            string registrationLink = "http://klooz.be/Identity/Account/Register";
            var toEmail = InviteEmail;
            string subject = "Uitnodiging registratie klooz";
            string body = $@"Hey! 
Via onderstaande link kan je een account aanmaken bij klooz en je experiment aanmaken. 
Wanneer het experiment goedgekeurd is, zal dit online verschijnen.

{registrationLink}

Met vriendelijke groeten
Team klooz";

            Console.WriteLine($"Email: {InviteEmail}");
            await _emailService.SendEmailAsync(toEmail, subject, body);

            return RedirectToAction("Index");
        }
    }
}
