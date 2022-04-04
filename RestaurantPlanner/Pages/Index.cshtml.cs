using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RestaurantPlanner.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
       
    }
}