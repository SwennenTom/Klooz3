using Microsoft.AspNetCore.Identity;
using Klooz3.Models;

namespace Klooz3.Data
{
    public class SeedData
    {
        static ApplicationDbContext? _context;
        static RoleManager<IdentityRole>? _roleManager;
        static UserManager<ApplicationUser>? _userManager;

        public static async Task VoegRolToeAsync(RoleManager<IdentityRole> _roleManager, string roleName)
        {
            if (_roleManager != null && !await _roleManager.RoleExistsAsync(roleName))
            {
                IdentityRole role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);
            }
        }

        private static async Task VoegRollenToeAsync(ApplicationDbContext _context, RoleManager<IdentityRole> _roleManager)
        {
            if (_roleManager != null && !_roleManager.Roles.Any())
            {
                await VoegRolToeAsync(_roleManager, Roles.regierol);
                await VoegRolToeAsync(_roleManager, Roles.gebruikerrol);
                await VoegRolToeAsync(_roleManager, Roles.adminrol);
            }
        }

        public static async Task EnsurePopulatedAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await VoegRollenToeAsync(_context, _roleManager);
                await CreateIdentityUserAsync(_userManager);
                //await CreateIdentityRecordAsync(Roles.regierol, "student@pxl.be", "Student1!", Roles.regierol);
                //await CreateIdentityRecordAsync(Roles.gebruikerrol, "lector@pxl.be", "Lector1!", Roles.gebruikerrol);
                //await CreateIdentityRecordAsync(Roles.adminrol, "admin@pxl.be", "Admin1!", Roles.adminrol);
            }
        }

        private static async Task CreateIdentityUserAsync(UserManager<ApplicationUser> _userManager)
        {
            string firstname = "Tom";
            string lastname = "Swennen";
            string phonenumber = "0498147788";
            string email = "tswennen@gmail.com";
            string organization = "nvt";
            string password = "O826o826";

            if (_userManager != null && await _userManager.FindByEmailAsync(email) == null)
            {
                var identityUser = new ApplicationUser() { Firstname = firstname,Lastname=lastname,PhoneNumber=phonenumber,Organization=organization, Email = email };
                var result = await _userManager.CreateAsync(identityUser, password);
                if (result.Succeeded)
                {
                    // Add the user to a role if needed
                    await _userManager.AddToRoleAsync(identityUser, "adminrol");

                    // You can customize this part based on your needs
                    Console.WriteLine("User created successfully!");
                }
                else
                {
                    // Handle errors if user creation fails
                    Console.WriteLine("Error creating user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
        }

        private static async Task CreateIdentityRecordAsync(string userName, string email, string pwd, string role)
        {

            if (_userManager != null && await _userManager.FindByEmailAsync(email) == null &&
                    await _userManager.FindByNameAsync(userName) == null)
            {
                var identityUser = new ApplicationUser() { Email = email, UserName = userName };
                var result = await _userManager.CreateAsync(identityUser, pwd);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, role);
                }
            }
        }

        public static void Seed(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.categories.Any())
            {
                context.categories.AddRange(
                    new Categories { name = "Innovatieve landbouw" },
                    new Categories { name = "Vrijetijdseconomie" },
                    new Categories { name = "Creatief" },
                    new Categories { name = "Duurzaam toerisme" },
                    new Categories { name = "Leerplek" },
                    new Categories { name = "Mijn experiment behoort niet tot één van deze thema's" });

                context.SaveChanges();

                //try { context.SaveChanges(); }
                //catch (Exception ex)
                //{
                //    Console.WriteLine("An error occurred while saving changes: " + ex.Message);
                //}
            }

            if(!context.teamregies.Any())
            {
                context.teamregies.AddRange(
                    new TeamRegie { Name = "Nele Bylois", Emailadress = "nele@klooz.be" },
                    new TeamRegie { Name = "Valerie Spec", Emailadress = "valerie@klooz.be" });

                context.SaveChanges();
            }




        }
    }
}
