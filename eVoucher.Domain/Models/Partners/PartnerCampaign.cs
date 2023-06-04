using eVoucher.Domain.SeekWork;

namespace eVoucher.Domain.Models
{
    public class PartnerCampaign : Entity
    {
        public virtual Campaign Campaign { get; set; }
        public virtual Partner Partner { get; set; }
    }
}

