using eVoucher.Domain.SeekWork;
using static eVoucher.Domain.DataType;

namespace eVoucher.Domain.Models
{
    public class Address : Entity
    {
        public virtual string Stress { get; set; }
        public virtual string District { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual string State { get; set; }
        public virtual eAddressType Type { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
