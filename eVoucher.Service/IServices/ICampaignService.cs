using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.Serivces
{
    public interface ICampaignService
    {
        Task<Campaign> CreateUser(GameDto gameDto);
        Task<CampaignDto> GetCampaignById(Guid id);
        Task<bool> UpdateCampaign(CampaignDto CampaignDto);
        Task<bool> DeleteCampaign(Guid id);
        Task<Campaign> UpdateCampaign(UpdateCampaignDto CampaignDto);
        Task<bool> EditGame(GameDto gameDto);
        Task<bool> DeleteGame(Guid id);

    }
}
