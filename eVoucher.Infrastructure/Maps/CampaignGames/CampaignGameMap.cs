using eVoucher.Domain.Models;

namespace eVoucher.Infrastructure.Maps
{
    public class CampaignGameMap : EntityMap<CampaignGame>
    {
        public CampaignGameMap()
        {
            Table("CampaignGame");

            //Map(p => p.FirstName);
            
    }
}