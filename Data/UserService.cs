using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Klooz3.Models;
using Microsoft.EntityFrameworkCore;

namespace Klooz3.Data
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<IdentityUser>> GetRegisteredUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}
