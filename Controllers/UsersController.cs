using Klooz3.Data;
using Klooz3.Models;
using Klooz3.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klooz3.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserService userService, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetRegisteredUsersAsync();
            var usersWithRoles = new List<UserWithRolesViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                usersWithRoles.Add(new UserWithRolesViewModel
                {
                    User = user,
                    Roles = roles
                });
            }

            return View(usersWithRoles);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _userManager.GetRolesAsync(user);

            // Query the available roles using the RoleManager or any other method
            var availableRoles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            var model = new EditUserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                SelectedRole = roles.FirstOrDefault(),
                AvailableRoles = availableRoles // Populate AvailableRoles with available roles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, EditUserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Update user's roles based on the model.SelectedRoles
            var userRoles = await _userManager.GetRolesAsync(user);

            var roleToAdd = model.SelectedRole;
            var rolesToRemove = userRoles.Except(new[] { roleToAdd });

            await _userManager.AddToRoleAsync(user, roleToAdd);
            await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

            return RedirectToAction("Index"); // Redirect to the user list
        }
    }
}
