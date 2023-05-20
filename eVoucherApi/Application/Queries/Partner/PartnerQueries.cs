using Dapper;
using eVoucherApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace eVoucher.Services.Api.Application.Queries;
public class PartnerQueries: IPartnerQueries
{
    private string _connectionString;

    public PartnerQueries(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IList<Partner>> GetPartners()
    {
        var Partners = new List<Partner>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var parameters = new DynamicParameters();

            var result = await connection.QueryAsync<Partner>(@"spr_eVoucherApi_GetPartners", commandType: CommandType.StoredProcedure);
            Partners = result.AsList<Partner>();
        }

        return Partners;
    }
}
