using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Klooz3.Models;
using Microsoft.EntityFrameworkCore;

namespace Klooz3.Data
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<ApplicationUser>> GetRegisteredUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}
