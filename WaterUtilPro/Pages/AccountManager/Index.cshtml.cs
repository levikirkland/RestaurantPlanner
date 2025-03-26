using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WaterUtilPro.Pages.AccountManager
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class IndexModel : PageModel
    {
        public string CurrentFilter { get; set; }

        public void OnGet()
        {
        }
    }
}
