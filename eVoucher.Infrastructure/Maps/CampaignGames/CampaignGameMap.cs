using eVoucher.Domain.Models;
using eVoucherApi.domain.Models;

namespace eVoucher.Infrastructure.Maps
{
    public class CampaignGameMap : EntityMap<CampaignGame>
    {
        public CampaignGameMap()
        {
            Table("CampaignGame");

            References<Campaign>(x => x.Campaign)
                .Column("Campaign_ID");

            References<Game>(x => x.Game)
                .Column("Game_ID");
        }
    }
}