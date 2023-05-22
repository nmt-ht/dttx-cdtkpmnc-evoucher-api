using eVoucher.Domain.SeekWork;
using static eVoucher.Domain.Models.DataType;

namespace eVoucher.Domain.Models
{
    public class Address : Entity
    {
        public virtual string? Street { get; set; }
        public virtual string? District { get; set; }
        public virtual string? City { get; set; }
        public virtual string? Country { get; set; }
        public virtual eAddressType Type { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual User? User { get; set; }
    }
}
