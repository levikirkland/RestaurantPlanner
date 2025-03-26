using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;

namespace WaterUtilPro.Pages.VendorManager
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IVendorRepository _repo;

        public DetailsModel(IVendorRepository repo)
        {
            _repo = repo;
        }

        public Vendor Vendor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var vendor = await _repo.GetById((int)id!);

            if (vendor == null)
            {
                return NotFound();
            }
            else
            {
                Vendor = vendor;
            }

            return Page();
        }
    }
}
