using eVoucher.Domain.Models;
using eVoucher.Domain.SeekWork;
namespace eVoucherApi.Domain.Models
{
    public class CampaignUser : Entity
    {
        public virtual User User { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual DateTime JoinDate { get; set; }
    }
}