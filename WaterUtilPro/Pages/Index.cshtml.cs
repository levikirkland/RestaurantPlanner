using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models.ViewModels;

namespace WaterUtilPro.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IOrderRepository _ordRepo;

        public IndexModel(IOrderRepository ordRepo)
        {
            _ordRepo = ordRepo;
        }

        public List<OrderDetails> OrderDetails { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            OrderDetails = await _ordRepo.GetDetailsAsync();
            return Page();
        }
    }
}