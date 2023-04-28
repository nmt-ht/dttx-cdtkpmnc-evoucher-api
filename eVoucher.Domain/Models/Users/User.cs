using eVoucher.Domain.SeekWork;

namespace eVoucher.Domain.Models
{
    public class User : Entity
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string? EmailAddress { get; set; }
        public virtual string? Phone { get; set; }
        public virtual string? UserName { get; set; }
        public virtual string? Password { get; set; }
        public virtual IList<Address>? Addresses { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
