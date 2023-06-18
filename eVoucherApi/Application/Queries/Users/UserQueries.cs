using Dapper;
using eVoucher.Service.Dtos;
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

        public async Task<IList<UserGroupDto>> GetUserGroups()
        {
            var userGroups = new List<UserGroupDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<UserGroupDto>(@"spr_eVoucherApi_GetUserGroups", commandType: CommandType.StoredProcedure);
                userGroups = result.AsList();
            }

            return userGroups;
        }

        public async Task<IList<UserDto>> GetUsers()
        {
            var users = new List<UserDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
            
                var result = await connection.QueryAsync<UserDto>(@"spr_eVoucherApi_GetUsers", commandType: CommandType.StoredProcedure);
                users = result.AsList();
            }

            return users;
        }

        public async Task<IList<UserVoucherDto>> GetUserVouchers(Guid currentUserId)
        {
            var users = new List<UserVoucherDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var parametters = new DynamicParameters();
                parametters.Add("@CurrentUserID", currentUserId);

                var result = await connection.QueryAsync<UserVoucherDto>(@"spr_eVoucherApi_GetUserVouchers", parametters, commandType: CommandType.StoredProcedure);
                users = result.AsList();
            }

            return users;
        }
    }
}
