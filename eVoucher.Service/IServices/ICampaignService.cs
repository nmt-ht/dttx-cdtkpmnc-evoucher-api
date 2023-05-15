using eVoucher.Domain.Models;

namespace eVoucher.Service.Serivces
{
    public interface ICampaignService
    {
        Campaign GetCampaignById(Guid id);
    }
}
