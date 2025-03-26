using WaterUtilPro.Models;

namespace WaterUtilPro.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAsync();
    }
}