using eVoucher.Domain.Models;

namespace eVoucher.Infrastructure.Maps;
public class UserGroupMap : EntityMap<UserGroup>
{
    public UserGroupMap()
    {
        Table("UserGroup");

        Map(g => g.Name);
        Map(g => g.Description);
        Map(g => g.IsActive);

        HasManyToMany<User>(x => x.Users)
           .Table("UserGroupLink")
           .ParentKeyColumn("UserGroup_ID_FK")
           .ChildKeyColumn("User_ID_FK")
           .AsBag();

        HasMany(x => x.UserGroupLinks)
            .Inverse()
            .Cascade.AllDeleteOrphan();
    }
}
