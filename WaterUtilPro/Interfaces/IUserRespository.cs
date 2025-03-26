using WaterUtilPro.Models;

namespace WaterUtilPro.Interfaces
{
    public interface IUserRespository
    {
        Task<List<ApplicationUser>> GetAll();
    }
}