using Microsoft.AspNetCore.Identity;
using RestaurantPlanner.Common.Enums;
using RestaurantPlanner.Interfaces;
using RestaurantPlanner.Models;

namespace RestaurantPlanner.Services
{

    public class InitializationService : IInitializationService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public InitializationService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedNewSuperAdminUser(AccountInfo accountInfo)
        {
            //Seed User
            var defaultUser = new ApplicationUser
            {
                UserName = accountInfo.EmailAddress,
                Email = accountInfo.EmailAddress,
                FirstName = accountInfo.FirstName,
                LastName = accountInfo.LastName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedBy = "api-SeedNewSuperAdmin",
                ModifiedBy = "api-SeedNewSuperAdmin",
                AccountInfoId = accountInfo.Id
            };
            if (_userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await _userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await _userManager.CreateAsync(defaultUser, "Ez(12345");
                    await _userManager.AddToRoleAsync(defaultUser, Roles.Associate.ToString());
                    await _userManager.AddToRoleAsync(defaultUser, Roles.Manager.ToString());
                    await _userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    await _userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                }
            }
        }
    }
}
