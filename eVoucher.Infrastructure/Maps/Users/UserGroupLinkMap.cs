using eVoucher.Domain.Models;

namespace eVoucher.Infrastructure.Maps
{
    public class UserGroupLinkMap : EntityMap<UserGroupLink>
    {
        public UserGroupLinkMap()
        {
            Table("UserGroupLink");

            Id(x => x.Id).Column("ID").GeneratedBy.GuidComb();

            References(x => x.User)
            .Column("User_ID_FK")
            .Not.Nullable();

            References(x => x.UserGroup)
                .Column("UserGroup_ID_FK")
                .Not.Nullable();
        }
    }
}
