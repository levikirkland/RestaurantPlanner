using WaterUtilPro.Models;
using WaterUtilPro.Models.ViewModels;

namespace WaterUtilPro.Interfaces
{
    public interface IVendorRepository
    {
        Task<int> Add(Vendor vendor);
        Task<int> DeleteById(int Id);
        Task<List<InventoryDetails>> GetAllDetails();
        Task<List<Vendor>> GetAsync();
        Task<Vendor> GetById(int id);
        Task<Vendor> GetDetailsById(int Id);
        Task<int> UpdateById(Vendor vendor);
    }
}
