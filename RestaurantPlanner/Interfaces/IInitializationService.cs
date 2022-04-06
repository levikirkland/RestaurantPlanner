using RestaurantPlanner.Models;

namespace RestaurantPlanner.Interfaces
{
    public interface IInitializationService
    {
        Task SeedNewSuperAdminUser(AccountInfo accountInfo);
    }
}