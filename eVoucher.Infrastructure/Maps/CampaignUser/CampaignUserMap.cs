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

            References<User>(x => x.User)
               .Column("User_ID_FK");

            References<Campaign>(x => x.Campaign)
                .Column("Campaign_ID_FK");
        }
    }
}
