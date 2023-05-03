using eVoucher.Domain.Models;
using eVoucherApi.Domain.Models;

namespace eVoucher.Infrastructure.Maps
{
    public class CampaignUserMap : EntityMap<CampaignUser>
    {
        public CampaignUserMap()
        {
            Table("CampaignUser");

            Map(p => p.JoinDate);
           

            HasMany<Campaign>(p => p.Campaign_ID)
                   .Table("Campaign")
                   .KeyColumn("Campaign_ID")
                   .Cascade.AllDeleteOrphan();
            HasMany<User>(p => p.User_ID)
                   .Table("User")
                   .KeyColumn("User_ID")
                   .Cascade.AllDeleteOrphan();
        }
    }
}
