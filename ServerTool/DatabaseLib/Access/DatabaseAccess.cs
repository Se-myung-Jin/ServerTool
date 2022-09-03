using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseLib
{
    public class DatabaseAccess : IDatabaseAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionString { get; set; } = "Default";

        public DatabaseAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionString);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }

        public async Task<bool> SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionString);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var result = await connection.ExecuteAsync(sql, parameters);

                if (1 != result)
                {
                    return false;
                }
            }

            return true;
        }
    }
}