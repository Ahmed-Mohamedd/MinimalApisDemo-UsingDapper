using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration=configuration;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string StoredProcedure, U Parameters, string ConnectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(ConnectionId));
            return await connection.QueryAsync<T>(StoredProcedure, Parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string StoredProcedure, T Parameters, string ConnectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(ConnectionId));
            await connection.ExecuteAsync(StoredProcedure, Parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
