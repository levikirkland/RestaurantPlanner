using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;

namespace WaterUtilPro.Pages.VendorManager
{
    [Authorize(Roles = "Admin,Manager")]
    public class EditModel : PageModel
    {
        private readonly IVendorRepository _repo;

        public EditModel(IVendorRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Vendor Vendor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var vendor = await _repo.GetById(id);
            if (vendor == null)
            {
                return NotFound();
            }
            Vendor = vendor;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int Id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Vendor.Id = Id;

            await _repo.UpdateById(Vendor);


            return RedirectToPage("./Index");
        }
    }
}

