using eVoucher.Domain.Models;

namespace eVoucher.Infrastructure.Maps
{
    public class PartnerCampaignMap : EntityMap<PartnerCampaign>
    {
        public PartnerCampaignMap()
        {
            Table("PartnerCampaign");

            References<Campaign>(x => x.Campaign)
                .Column("Campaign_ID_FK");

            References<Partner>(x => x.Partner)
                .Column("Partner_ID_FK");
        }
    }
}