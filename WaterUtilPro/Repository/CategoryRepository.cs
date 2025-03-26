using WaterUtilPro.Interfaces;
using WaterUtilPro.Models;
using WaterUtilPro.Repository.SqlStatements;

namespace WaterUtilPro.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ISqlDataAccess _db;

        public CategoryRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            var cts = new CancellationTokenSource();

            return await _db.LoadDataAsync<Category, dynamic>(SqlQueries.Category.GetAll, null, ConnStrings.DefaultConnectionString, System.Data.CommandType.Text, cts.Token);
        }

    }
}
