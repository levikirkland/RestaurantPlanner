using WaterUtilPro.Models;

namespace WaterUtilPro.Interfaces
{
    public interface IUnitOfMeasureRepository
    {
        Task<IEnumerable<UnitOfMeasure>> GetAsync();
    }
}