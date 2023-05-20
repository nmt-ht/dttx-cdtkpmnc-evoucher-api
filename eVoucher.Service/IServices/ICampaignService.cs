using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.Serivces
{
    public interface ICampaignService
    {
        Campaign GetCampaignById(Guid id);
        Task<bool> UpdateCampaign(CampaignDto CampaignDto);
        Task<bool> DeleteCampaign(Guid id);
    }
}
