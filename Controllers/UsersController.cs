using Klooz3.Data;
using Klooz3.Models;
using Klooz3.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Klooz3.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserService userService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin, TeamRegie")]
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

        [Authorize(Roles = "Admin, TeamRegie")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var loggedInUser = await _userManager.GetUserAsync(User);

            if (await _userManager.IsInRoleAsync(loggedInUser, "TeamRegie"))
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    TempData["ErrorMessage"] = "Je kan geen admin bewerken.";
                    return RedirectToAction("Index");
                }

            }
                var roles = await _userManager.GetRolesAsync(user);
                var availableRoles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

                var model = new EditUserRolesViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    SelectedRole = roles.FirstOrDefault(),
                    AvailableRoles = availableRoles
                };

                return View(model);
            
        }

        [HttpPost]
        [Authorize(Roles = "Admin, TeamRegie")]
        public async Task<IActionResult> Edit(string id, EditUserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var loggedInUser = await _userManager.GetUserAsync(User);
            if (await _userManager.IsInRoleAsync(loggedInUser,"TeamRegie"))
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    TempData["ErrorMessage"] = "Je kan geen admin bewerken.";
                    return RedirectToAction("Index");
                }
            }
            
            // Update user's roles based on the model.SelectedRoles
            var userRoles = await _userManager.GetRolesAsync(user);

            var roleToAdd = model.SelectedRole;
            var rolesToRemove = userRoles.Except(new[] { roleToAdd });

            await _userManager.AddToRoleAsync(user, roleToAdd);
            await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

            return RedirectToAction("Index"); // Redirect to the user list
        }

        [Authorize(Roles = "Admin, TeamRegie")]
        public async Task<IActionResult> Delete(string id)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }


            if (await _userManager.IsInRoleAsync(loggedInUser, "TeamRegie"))
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    TempData["ErrorMessage"] = "Je kan geen admin verwijderen.";
                    return RedirectToAction("Index");
                }

            }


            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, TeamRegie")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var loggedInUser = await _userManager.GetUserAsync(User);
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            if(await _userManager.IsInRoleAsync(loggedInUser, "TeamRegie"))
            {
                // Check if the user being deleted is an admin
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    TempData["ErrorMessage"] = "Je kan geen admin verwijderen.";
                    return RedirectToAction("Index");
                }
            }
            

            // Check if the user being deleted is the last user with TeamRegie role
            var usersWithTeamRegieRoleCount = await _userManager.GetUsersInRoleAsync("TeamRegie");

            if (usersWithTeamRegieRoleCount.Count == 1 && await _userManager.IsInRoleAsync(user, "TeamRegie"))
            {
                TempData["ErrorMessage"] = "Je kan het laatste lid van Team Regie niet verwijderen. Geef eerst een andere gebruiker deze rol.";
                return RedirectToAction("Index");
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Handle errors, e.g., display an error message
                return View(user);
            }
        }

    }
}
