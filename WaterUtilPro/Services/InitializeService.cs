using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;
using WaterUtilPro.Common.Enums;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;

namespace WaterUtilPro.Services
{
    public class InitializationService : IInitializationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public InitializationService(UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task SeedNewSuperAdminUser(Account accountInfo)
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
                AccountInfoId = accountInfo.Id,
                Active = true
            };

            var user = await _userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)  //email not found, continue with create
            {
                await _userManager.CreateAsync(defaultUser, "Ez(12345");
                await _userManager.AddToRoleAsync(defaultUser, Roles.Associate.ToString());
                await _userManager.AddToRoleAsync(defaultUser, Roles.Manager.ToString());
                await _userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                await _userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
            }

            await _emailSender.SendEmailAsync(defaultUser.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode("#")}'>clicking here</a>.");
        }
    }
}