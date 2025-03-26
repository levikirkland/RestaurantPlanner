using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models.ViewModels;

namespace WaterUtilPro.Pages.InventoryManager
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IInventoryRepository _repo;

        public string CurrentFilter { get; set; }
        public IndexModel(IInventoryRepository repo)
        {
            _repo = repo;
        }

        public IList<InventoryDetails> Inventory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            var inventoryDetails = await _repo.GetAllDetails();

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
