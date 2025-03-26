using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;

namespace WaterUtilPro.Pages.UserManager;

[Authorize]
public class UserProfile : PageModel
{
    private readonly ICurrentUserService _currentUser;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserProfile(ICurrentUserService currentUser, UserManager<ApplicationUser> UserManager)
    {
        _currentUser = currentUser;
        _userManager = UserManager;
    }


    public ApplicationUser? user { get; set; }
    public IList<string>? roles { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var userId = _currentUser.UserId!.ToString();
        user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound();
        }
        roles = await _userManager.GetRolesAsync(user);
        return Page();
    }
}