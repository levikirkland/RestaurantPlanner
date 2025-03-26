using Dapper;
using Microsoft.Data.SqlClient;
using WaterUtilPro.Interfaces;
using System.Data;

namespace WaterUtilPro.Repository
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public string GetConnectionString(string name)
        {
            return _config.GetConnectionString(name)!;
        }

        public async Task<T> LoadSingleDataAsync<T, U>(string sql, U parameters, string connectionStringName, CommandType commandType, CancellationToken cancellationToken)
        {

            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var data = await connection.QueryAsync<T>(sql, parameters, commandType: commandType);
                    return (T)data.FirstOrDefault()!;
                }
                catch (SqlException)
                { return (T)default!; }
            }
        }

        public async Task<List<T>> LoadDataAsync<T, U>(string sql, U parameters, string connectionStringName, CommandType commandType, CancellationToken cancellationToken)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    var data = await connection.QueryAsync<T>(sql, parameters, commandType: commandType);
                    return data.ToList();
                }
                catch (SqlException)
                { return default(List<T>)!; }
            }
        }

        public async Task<int> SaveData<T>(string sql, T parameters, string connectionStringName, CommandType commandType, CancellationToken cancellationToken)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    return await connection.ExecuteAsync(sql, parameters, commandType: commandType);
                }
                catch (SqlException)
                {
                    return default(int);
                }
            }
        }


    }
}
