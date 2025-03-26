using WaterUtilPro.Models;
using WaterUtilPro.Models.ViewModels;

namespace WaterUtilPro.Interfaces
{
    public interface IInventoryRepository
    {
        Task<int> Add(Inventory inventory);
        Task<int> DeleteById(int Id);
        Task<List<InventoryDetails>> GetAllDetails();
        Task<List<Inventory>> GetAsync();
        Task<Inventory> GetById(int id);
        Task<InventoryDetails> GetDetailsById(int Id);
        Task<int> UpdateById(Inventory inventory);
    }
}