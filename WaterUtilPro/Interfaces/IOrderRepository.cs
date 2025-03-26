using WaterUtilPro.Models;
using WaterUtilPro.Models.ViewModels;

namespace WaterUtilPro.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> Add(Order order);
        Task<int> DeleteById(int Id);
        Task<List<Order>> GetAsync();
        Task<List<OrderDetails>> GetDetailsAsync();
        Task<Order> GetById(int id);
        Task<OrderDetails> GetDetailsByIdAsync(int Id);
        Task<int> UpdateById(Order order);
    }
}
