using eVoucher.Domain.SeekWork;

namespace eVoucher.Domain.Models
{
    public class UserGroupLink : Entity
    {
        public virtual User User { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
