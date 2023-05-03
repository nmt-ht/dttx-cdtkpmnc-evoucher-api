using eVoucher.Domain.Models;
using eVoucher.Domain.SeekWork;
namespace eVoucherApi.Domain.Models
{
    public class CampaignUser : Entity
    {
        public virtual IList<User>? Users { get; set; }
        public virtual IList<Campaign>? Campaigns { get; set; }
        public virtual DateTime JoinDate { get; set; }
    }
}