using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;

namespace WaterUtilPro.Pages.Settings
{
    [Authorize(Roles = "Admin,Manager")]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfMeasureRepository _uomRepo;
        private readonly ICategoryRepository _catRepo;
        private readonly IUserRespository _userRepo;

        public IEnumerable<UnitOfMeasure> UnitOfMeasures { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }

        public IndexModel(IUnitOfMeasureRepository uomRepo, ICategoryRepository catRepo, IUserRespository userRepo)
        {
            _uomRepo = uomRepo;
            _catRepo = catRepo;
            _userRepo = userRepo;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            UnitOfMeasures = await _uomRepo.GetAsync();
            Categories = await _catRepo.GetAsync();
            Users = await _userRepo.GetAll();
            return Page();
        }
    }
}
