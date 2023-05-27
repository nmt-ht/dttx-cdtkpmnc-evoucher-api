using Dapper;
using eVoucher.Service.Dtos;
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

    public async Task<IList<PartnerDto>> GetPartners()
    {
        var partners = new List<PartnerDto>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var parameters = new DynamicParameters();

            var result = await connection.QueryAsync<PartnerDto>(@"spr_eVoucherApi_GetPartners", commandType: CommandType.StoredProcedure);
            partners = result.AsList<PartnerDto>();
        }

        return partners;
    }
}
