using eVoucher.Domain.Models;

namespace eVoucher.Service.Dtos
{
    public class PartnerCampaignDto
    {
        public Guid ID { get; set; }
        public CampaignDto Campaign { get; set; }
    }
}
