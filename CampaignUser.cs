using eVoucher.Domain.SeekWork;
namespace eVoucherApi.Domain.Models
{
    public class CampaignUser : Entity
    {
        public virtual string? User_ID { get; set; }
        public virtual string? Campaign_ID { get; set; }
        public virtual DateTime JoinDate { get; set; }
    }
}