using Dapper;
using eVoucherApi.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace eVoucher.Services.Api.Application.Queries
{
    public class UserQueries : IUserQueries
    {
        private string _connectionString;

        public UserQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IList<User>> GetUsers(Guid id = default)
        {
            var users = new List<User>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@ID", id);
            
                var result = await connection.QueryAsync<User>(@"spr_eVoucherApi_GetUsers", parameters, commandType: CommandType.StoredProcedure);
                users = result.AsList();
            }

            return users;
        }

        public async Task<bool> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
