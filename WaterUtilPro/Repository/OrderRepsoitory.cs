using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;
using WaterUtilPro.Models.ViewModels;
using WaterUtilPro.Repository.SqlStatements;

namespace WaterUtilPro.Repository
{
    public class OrderRepsoitory : IOrderRepository
    {
        private readonly ISqlDataAccess _db;

        public OrderRepsoitory(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<int> Add(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDetails>> GetDetailsAsync()
        {
            var cts = new CancellationTokenSource();
            return await _db.LoadDataAsync<OrderDetails, dynamic>(SqlQueries.Orders.GetOrdersDetails, null!, ConnStrings.DefaultConnectionString, System.Data.CommandType.Text, cts.Token);
        }

        public Task<Order> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDetails> GetDetailsByIdAsync(int Id)
        {
            var cts = new CancellationTokenSource();
            return await _db.LoadSingleDataAsync<OrderDetails, dynamic>(SqlQueries.Orders.GetOrdersDetailsById, new { Id = Id }, ConnStrings.DefaultConnectionString, System.Data.CommandType.Text, cts.Token);
        }

        public Task<int> UpdateById(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}