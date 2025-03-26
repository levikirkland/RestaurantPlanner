using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models.ViewModels;

namespace WaterUtilPro.Pages.Orders
{
    public class CartModel : PageModel
    {
        private readonly IOrderRepository _repo;

        public CartModel(IOrderRepository repo)
        {
            _repo = repo;
        }

        public List<OrderDetails> Orders { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Orders = await _repo.GetDetailsAsync();
            if (Orders == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
