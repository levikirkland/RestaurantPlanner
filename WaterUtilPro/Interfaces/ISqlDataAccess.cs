

using System.Data;

namespace WaterUtilPro.Interfaces
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadDataAsync<T, U>(string sql, U parameters, string connectionStringName, CommandType commandType, CancellationToken cancellationToken);
        Task<T> LoadSingleDataAsync<T, U>(string sql, U parameters, string connectionStringName, CommandType commandType, CancellationToken cancellationToken);
        Task<int> SaveData<T>(string sql, T parameters, string connectionStringName, CommandType commandType, CancellationToken cancellationToken);
    }
}