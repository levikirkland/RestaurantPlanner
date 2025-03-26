using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models.ViewModels;

namespace WaterUtilPro.Pages.InventoryManager
{
    public class ExtendedDetailsModel : PageModel
    {
        private readonly IInventoryRepository _invRepo;

        public ExtendedDetailsModel(IInventoryRepository invRepo)
        {
            _invRepo = invRepo;
        }

        public InventoryDetails Inventory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            var inventoryDetails = await _invRepo.GetDetailsById((int)id!);

            if (inventoryDetails == null)
            {
                return NotFound();
            }
            else
            {
                Inventory = inventoryDetails;
            }

            return Page();
        }
    }
}
