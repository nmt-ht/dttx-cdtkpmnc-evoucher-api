using eVoucher.Service.Dtos;
using eVoucherApi.Models;

namespace eVoucher.Services.Api.Application.Queries;
public interface IReportQueries
{
    Task<IList<CampaignReportDto>> GetTotalOfCampaignByDate(ReportCampaignRequest reportCampaignRequest);
    Task<IList<VoucherReportDto>> GetTotalOfVouchers();
}

