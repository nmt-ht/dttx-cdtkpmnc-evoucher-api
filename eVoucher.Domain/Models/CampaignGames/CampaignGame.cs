using eVoucher.Domain.SeekWork;

namespace eVoucher.Domain.Models
{
    public class CampaignGame : Entity
    {
        public virtual Campaign Campaign { get; set; }
        public virtual Game Game { get; set; }
    }
}

