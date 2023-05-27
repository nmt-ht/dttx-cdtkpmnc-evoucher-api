using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.Serivces
{
    public interface ICampaignService
    {
        Task<CampaignDto> GetCampaignById(Guid id);
        Task<bool> UpdateCampaign(CampaignDto CampaignDto);
        Task<bool> DeleteCampaign(Guid id);
        Task<bool> EditGame(GameDto gameDto);
        Task<bool> DeleteGame(Guid id);

    }
}
