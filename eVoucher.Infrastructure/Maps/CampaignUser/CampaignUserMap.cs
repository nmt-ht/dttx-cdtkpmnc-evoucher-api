using eVoucher.Domain.Models;
using eVoucherApi.domain.Models;
using eVoucherApi.Domain.Models;

namespace eVoucher.Infrastructure.Maps
{
    public class CampaignUserMap : EntityMap<CampaignUser>
    {
        public CampaignUserMap()
        {
            Table("CampaignUser");
            Map(p => p.JoinDate);

            //HasMany<Campaign>(p => p.Campaigns)
            //       .Table("Campaign")
            //       .KeyColumn("Campaign_ID")
            //       .Cascade.AllDeleteOrphan();
            //HasMany<User>(p => p.Users)
            //       .Table("User")
            //       .KeyColumn("User_ID")
            //       .Cascade.AllDeleteOrphan();

            References<User>(x => x.User)
               .Column("User_ID");

            References<Campaign>(x => x.Campaign)
                .Column("Campaign_ID");
        }
    }
}
