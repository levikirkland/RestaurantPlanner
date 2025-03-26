using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;
using WaterUtilPro.Models.ViewModels;
using WaterUtilPro.Repository.SqlStatements;
using System.Data;

namespace WaterUtilPro.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ISqlDataAccess _db;
        private readonly ICurrentUserService _currentUser;

        public InventoryRepository(ISqlDataAccess db, ICurrentUserService currentUser)
        {
            _db = db;
            _currentUser = currentUser;
        }

        public async Task<List<Inventory>> GetAsync()
        {
            var cts = new CancellationTokenSource();
            return await _db.LoadDataAsync<Inventory, dynamic>(SqlQueries.Inventory.GetAll, null, ConnStrings.DefaultConnectionString, CommandType.Text, cts.Token);
        }

        public async Task<int> Add(Inventory inventory)
        {
            var cts = new CancellationTokenSource();
            var parameters = new
            {
                //Id = inventory.Id,
                Name = inventory.Name,
                CategoryId = inventory.CategoryId,
                Location = inventory.Location,
                QtyInStock = inventory.QtyInStock,
                ReorderQty = inventory.ReorderQty,
                UnitCost = inventory.UnitCost,
                ReStockDate = inventory.ReStockDate,
                ImageUrl = inventory.ImageUrl,
                CreatedDate = DateTime.Now,
                CreatedBy = _currentUser.UserId,
                IsActive = inventory.IsActive,
                UnitOfMeasureId = inventory.UnitOfMeasureId,
                Description = inventory.@Description
            };
            return await _db.SaveData(SqlCommands.Inventory.InsertInventory, parameters, ConnStrings.DefaultConnectionString, CommandType.Text, cts.Token);
        }

        public async Task<Inventory> GetById(int id)
        {
            var cts = new CancellationTokenSource();
            return await _db.LoadSingleDataAsync<Inventory, dynamic>(SqlQueries.Inventory.GetById, new { Id = id }, ConnStrings.DefaultConnectionString, CommandType.Text, cts.Token);
        }

        public async Task<int> DeleteById(int Id)
        {
            var cts = new CancellationTokenSource();
            return await _db.SaveData(SqlCommands.Inventory.DeleteInventoryByIdAsync, new { Id = Id }, ConnStrings.DefaultConnectionString, CommandType.Text, cts.Token);
        }

        public async Task<int> UpdateById(Inventory inventory)
        {
            var cts = new CancellationTokenSource();
            var parameters = new
            {
                Id = inventory.Id,
                Name = inventory.Name,
                CategoryId = inventory.CategoryId,
                Location = inventory.Location,
                QtyInStock = inventory.QtyInStock,
                ReorderQty = inventory.ReorderQty,
                UnitCost = inventory.UnitCost,
                ReStockDate = inventory.ReStockDate,
                ImageUrl = inventory.ImageUrl,
                ModifiedDate = DateTime.Now,
                ModifiedBy = _currentUser.UserId,
                IsActive = inventory.IsActive,
                UnitOfMeasureId = inventory.UnitOfMeasureId,
                Description = inventory.@Description
            };
            return await _db.SaveData(SqlCommands.Inventory.UpdateInventory, parameters, ConnStrings.DefaultConnectionString, CommandType.Text, cts.Token);
        }

        public async Task<InventoryDetails> GetDetailsById(int Id)
        {
            var cts = new CancellationTokenSource();
            return await _db.LoadSingleDataAsync<InventoryDetails, dynamic>(SqlQueries.Inventory.GetInventoryDetailsById, new { Id = Id }, ConnStrings.DefaultConnectionString, CommandType.Text, cts.Token);
        }

        public async Task<List<InventoryDetails>> GetAllDetails()
        {
            var cts = new CancellationTokenSource();
            return await _db.LoadDataAsync<InventoryDetails, dynamic>(SqlQueries.Inventory.GetAllInventoryDetails, null, ConnStrings.DefaultConnectionString, CommandType.Text, cts.Token);
        }
    }
}
