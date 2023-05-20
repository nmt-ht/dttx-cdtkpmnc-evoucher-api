using eVoucher.Domain.SeekWork;
using static eVoucher.Domain.Models.DataType;

namespace eVoucher.Domain.Models
{
    public class Partner : Entity
    {
        public virtual string? CompanyName { get; set; }
        public virtual string? Description { get; set; }
        public virtual string? CompanyEmailAddress { get; set; }
        public virtual string? CompanyPhone { get; set; }
        public virtual IList<Address>? CompanyAddess { get; set; }
        public virtual byte[]? Image { get; set; }
        public virtual DateTime? JoinDate { get; set; }
        public virtual ePartnerType Type { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual Guid User_ID { get; set;}
    }
}
