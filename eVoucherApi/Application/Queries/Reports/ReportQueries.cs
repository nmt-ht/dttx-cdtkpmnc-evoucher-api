using Dapper;
using eVoucher.Service.Dtos;
using eVoucherApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace eVoucher.Services.Api.Application.Queries;
public class ReportQueries : IReportQueries
{
    private string _connectionString;

    public ReportQueries(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IList<CampaignReportDto>> GetTotalOfCampaignByDate(ReportCampaignRequest reportCampaignRequest)
    {
        var reports = new List<CampaignReportDto>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var parameters = new DynamicParameters();
            if (reportCampaignRequest.CreatedDateFrom != DateTime.MinValue)
                parameters.Add("@CreatedDateFrom", reportCampaignRequest.CreatedDateFrom);
            if (reportCampaignRequest.CreatedDateTo != DateTime.MinValue)
                parameters.Add("@CreatedDateTo", reportCampaignRequest.CreatedDateTo);

            var result = await connection.QueryAsync<CampaignReportDto>(@"spr_eVoucherApi_Report_GetCampaigns", parameters, commandType: CommandType.StoredProcedure);
            reports = result.AsList<CampaignReportDto>();
        }

        return reports;
    }

    public async Task<IList<VoucherReportDto>> GetTotalOfVouchers()
    {
        var reports = new List<VoucherReportDto>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var result = await connection.QueryAsync<VoucherReportDto>(@"spr_eVoucherApi_Report_GetVoucherStatus", commandType: CommandType.StoredProcedure);
            reports = result.AsList<VoucherReportDto>();
        }

        return reports;
    }
}
