using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;

namespace WaterUtilPro.Pages.InventoryManager
{
    [Authorize(Roles = "Admin,Manager")]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfMeasureRepository _uomRepo;
        private readonly ICategoryRepository _catRepo;
        private readonly IInventoryRepository _invRepo;

        public CreateModel(IUnitOfMeasureRepository uomRepo, ICategoryRepository catRepo,
            IInventoryRepository invRepo)
        {
            _uomRepo = uomRepo;
            _catRepo = catRepo;
            _invRepo = invRepo;
        }

        public SelectList UnitOfMeasureOptions { get; set; }
        public SelectList CategoryOptions { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var uom = await _uomRepo.GetAsync();
            var categories = await _catRepo.GetAsync();

            UnitOfMeasureOptions = new SelectList(uom, nameof(UnitOfMeasure.Id), nameof(UnitOfMeasure.Name));
            CategoryOptions = new SelectList(categories, nameof(Category.Id), nameof(Category.Name));

            return Page();
        }

        [BindProperty]
        public Inventory Inventory { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var rowsAffected = await _invRepo.Add(Inventory);

            return RedirectToPage("./Index");
        }
    }
}
