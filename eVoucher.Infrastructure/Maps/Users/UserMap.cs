using eVoucher.Domain.Models;

namespace eVoucher.Infrastructure.Maps
{
    public class UserMap : EntityMap<User>
    {
        public UserMap()
        {
            Table("[User]");

            Map(p => p.FirstName);
            Map(p => p.LastName);
            Map(p => p.DateOfBirth);
            Map(p => p.EmailAddress);
            Map(p => p.Phone);
            Map(p => p.UserName);
            Map(p => p.Password);
            Map(p => p.IsActive);

            HasMany(p => p.Addresses)
                   .KeyColumn("User_ID_FK")
                   .Inverse()
                   .Cascade.AllDeleteOrphan();

            HasManyToMany<UserGroup>(x => x.UserGroups)
             .Table("UserGroupLink")
             .ParentKeyColumn("User_ID_FK")
             .ChildKeyColumn("UserGroup_ID_FK")
             .AsBag();
        }
    }
}
