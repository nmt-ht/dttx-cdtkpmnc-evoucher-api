using eVoucher.Domain.Models;

namespace eVoucher.Infrastructure.Maps
{
    public class CampaignMap : EntityMap<Campaign>
    {
        public CampaignMap()
        {
            Table("Campaign");

            Map(p => p.Name);
            Map(p => p.Description);
            Map(p => p.CreatedDate);
            Map(p => p.StartedDate);
            Map(p => p.ExpiredDate);
            Map(p => p.ModifiedDate);
            Map(p => p.IsDeleted);
            
            References<User>(x => x.CreatedBy)
                .Column("CreatedBy");

            References<User>(x => x.ModifiedBy)
                .Column("ModifiedBy");
        }
    }
}
