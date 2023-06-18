using Dapper;
using eVoucher.Service.Dtos;
using System.Data;
using System.Data.SqlClient;

namespace eVoucher.Services.Api.Application.Queries;
public class ReportQueries:IReportQueries
{
    private string _connectionString;

    public ReportQueries(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IList<ReportDto>> GetAllCampaigns()
    {
        var reports = new List<ReportDto>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var parameters = new DynamicParameters();

            var result = await connection.QueryAsync<ReportDto>(@"spr_GetAllCampaign", commandType: CommandType.StoredProcedure);
            reports = result.AsList<ReportDto>();
        }

        return reports;
    }

}
