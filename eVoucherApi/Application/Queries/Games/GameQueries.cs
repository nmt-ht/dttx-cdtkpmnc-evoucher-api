using Dapper;
using eVoucher.Service.Dtos;
using eVoucherApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace eVoucher.Services.Api.Application.Queries;
public class GameQueries: IGameQueries
{
    private string _connectionString;

    public GameQueries(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IList<GameDto>> GetGames()
    {
        var games = new List<GameDto>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var parameters = new DynamicParameters();

            var result = await connection.QueryAsync<GameDto>(@"spr_eVoucherApi_GetGames", commandType: CommandType.StoredProcedure);
            games = result.AsList<GameDto>();
        }

        return games;
    }
}
