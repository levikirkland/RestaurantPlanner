using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterUtilPro.Models;

namespace WaterUtilPro.Pages.Test
{
   
    public class IndexModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        [BindProperty]
        public string? UserName { get; set; }    
        public IndexModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public void OnGet()
        {
            if (_signInManager.IsSignedIn(User))
            {
                UserName = User.Identity.Name.ToString();
            }
        }
    }
}
