using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;
using WaterUtilPro.Repository.SqlStatements;

namespace WaterUtilPro.Repository
{
    public class UserRespository : IUserRespository
    {
        private readonly ISqlDataAccess _db;

        public UserRespository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            var cts = new CancellationTokenSource();
            return await _db.LoadDataAsync<ApplicationUser, dynamic>(SqlQueries.Users.GetUsers, null, ConnStrings.DefaultConnectionString, System.Data.CommandType.Text, cts.Token);

        }
    }
}
