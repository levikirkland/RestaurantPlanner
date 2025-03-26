using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;

namespace WaterUtilPro.Pages.VendorManager
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IVendorRepository _repo;

        public IndexModel(IVendorRepository repo)
        {
            _repo = repo;
        }

        public string CurrentFilter { get; set; }

        public IList<Vendor> Vendor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var vendors = await _repo.GetAsync();

            if (vendors == null)
            {
                return NotFound();
            }
            else
            {
                Vendor = vendors;
            }
            return Page();
        }
    }
}
