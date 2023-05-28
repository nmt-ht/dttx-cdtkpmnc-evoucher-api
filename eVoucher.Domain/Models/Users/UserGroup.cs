using eVoucher.Domain.SeekWork;

namespace eVoucher.Domain.Models;

public class UserGroup : Entity
{
    public virtual string Name { get; set; }
    public virtual string Description { get; set; }
    public virtual bool IsActive { get; set; }
    public virtual IList<User> Users { get; set; }
    public virtual IList<UserGroupLink> UserGroupLinks { get; set; }
}
