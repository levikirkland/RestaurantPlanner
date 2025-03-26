using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;

namespace WaterUtilPro.Pages.InventoryManager
{
    [Authorize(Roles = "Admin,Manager")]
    public class EditModel : PageModel
    {
        private readonly IUnitOfMeasureRepository _uomRepo;
        private readonly ICategoryRepository _catRepo;
        private readonly IInventoryRepository _invRepo;

        public EditModel(IUnitOfMeasureRepository uomRepo, ICategoryRepository catRepo, IInventoryRepository invRepo)
        {
            _uomRepo = uomRepo;
            _catRepo = catRepo;
            _invRepo = invRepo;
        }

        [BindProperty]
        public Inventory Inventory { get; set; } = default!;

        public SelectList UnitOfMeasureOptions { get; set; }
        public SelectList CategoryOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var uom = await _uomRepo.GetAsync();
            var categories = await _catRepo.GetAsync();

            UnitOfMeasureOptions = new SelectList(uom, nameof(UnitOfMeasure.Id), nameof(UnitOfMeasure.Name));
            CategoryOptions = new SelectList(categories, nameof(Category.Id), nameof(Category.Name));

            var inventory = await _invRepo.GetById(id);
            if (inventory == null)
            {
                return NotFound();
            }
            Inventory = inventory;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int Id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Inventory.Id = Id;

            await _invRepo.UpdateById(Inventory);


            return RedirectToPage("./Index");
        }
    }
}