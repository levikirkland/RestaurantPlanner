using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models.ViewModels;

namespace WaterUtilPro.Pages.Orders
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IOrderRepository _repo;

        public DetailsModel(IOrderRepository repo)
        {
            _repo = repo;
        }

        public OrderDetails Orders { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var orders = await _repo.GetDetailsByIdAsync(id);

            if (orders == null)
            {
                return NotFound();
            }
            else
            {
                Orders = orders;
            }

            return Page();
        }
    }
}
