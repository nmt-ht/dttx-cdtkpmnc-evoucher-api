using eVoucherApi.Models;

namespace eVoucher.Services.Api.Application.Queries;
public interface ICampaignQueries
{
    Task<IList<CampaignDto>> GetCampaigns();
}
