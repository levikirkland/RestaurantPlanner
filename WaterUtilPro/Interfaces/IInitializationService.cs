using WaterUtilPro.Models;

namespace WaterUtilPro.Interfaces
{
    public interface IInitializationService
    {
        Task SeedNewSuperAdminUser(Account accountInfo);
    }
}