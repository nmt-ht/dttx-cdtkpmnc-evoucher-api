using eVoucher.Domain.Models;

namespace eVoucher.Service.Dtos
{
    public class CampaignGameDto
    {
        public Guid ID { get; set; }
        public GameDto Game { get; set; }
    }
}
