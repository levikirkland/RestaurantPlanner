using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;
using WaterUtilPro.Models.ViewModels;
using WaterUtilPro.Repository.SqlStatements;
using System.Data;

namespace WaterUtilPro.Repository
{
    public class VendorRepository : IVendorRepository
    {
        private readonly ISqlDataAccess _db;
        private readonly ICurrentUserService _currentUser;

        public VendorRepository(ISqlDataAccess db, ICurrentUserService currentUser)
        {
            _db = db;
            _currentUser = currentUser;
        }

        public async Task<int> Add(Vendor vendor)
        {
            var cts = new CancellationTokenSource();
            var parameters = new
            {
                Name = vendor.Name,
                Description = vendor.Description,
                Address = vendor.Address,
                City = vendor.City,
                State = vendor.State,
                PostalCode = vendor.PostalCode,
                Contact = vendor.Contact,
                EmailAddress = vendor.EmailAddress,
                Phone = vendor.Phone,
                CreatedBy = _currentUser.UserId,
                CreatedDate = DateTime.Now
            };
            return await _db.SaveData(SqlCommands.Vendor.InsertVendor, parameters,
                ConnStrings.DefaultConnectionString, CommandType.Text, cts.Token);

        }
        public Task<int> DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<InventoryDetails>> GetAllDetails()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Vendor>> GetAsync()
        {
            var cts = new CancellationTokenSource();
            return await _db.LoadDataAsync<Vendor, dynamic>(SqlQueries.Vendors.GetAll, null!,
                ConnStrings.DefaultConnectionString, CommandType.Text, cts.Token);

        }

        public async Task<Vendor> GetById(int id)
        {
            var cts = new CancellationTokenSource();
            return await _db.LoadSingleDataAsync<Vendor, dynamic>(SqlQueries.Vendors.GetById, new { Id = id }, ConnStrings.DefaultConnectionString, CommandType.Text, cts.Token);
        }

        public Task<Vendor> GetDetailsById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateById(Vendor vendor)
        {
            var cts = new CancellationTokenSource();
            var parameters = new
            {
                Name = vendor.Name,
                Description = vendor.Description,
                Address = vendor.Address,
                City = vendor.City,
                State = vendor.State,
                PostalCode = vendor.PostalCode,
                Contact = vendor.Contact,
                EmailAddress = vendor.EmailAddress,
                Phone = vendor.Phone,
                ModifiedBy = _currentUser.UserId,
                ModifiedDate = DateTime.Now
            };
            return await _db.SaveData(SqlCommands.Vendor.UpdateVendor, parameters,
                ConnStrings.DefaultConnectionString, CommandType.Text, cts.Token);
        }
    }
}
