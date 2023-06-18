using eVoucher.Domain.SeekWork;
using static eVoucher.Domain.Models.DataType;

namespace eVoucher.Domain.Models
{
    public class Report: Entity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime StartedDate { get; set; }
        public virtual DateTime ExpiredDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual User ModifiedBy { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual byte[]? Image { get; set; }
        public virtual IList<PartnerCampaign> PartnerCampaigns { get; set; }
    }
}
