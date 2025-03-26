using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;
using WaterUtilPro.Repository.SqlStatements;

namespace WaterUtilPro.Repository
{
    public class UnitOfMeasureRepository : IUnitOfMeasureRepository
    {
        private readonly ISqlDataAccess _db;

        public UnitOfMeasureRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<UnitOfMeasure>> GetAsync()
        {
            var cts = new CancellationTokenSource();

            return await _db.LoadDataAsync<UnitOfMeasure, dynamic>(SqlQueries.UnitOfMeasure.GetAll, null, "defaultConnection", System.Data.CommandType.Text, cts.Token);
        }
    }
}
