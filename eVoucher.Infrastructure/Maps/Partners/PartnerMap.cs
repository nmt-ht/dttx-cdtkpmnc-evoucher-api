using eVoucher.Domain.Models;

namespace eVoucher.Infrastructure.Maps
{
    public class PartnerMap : EntityMap<Partner>
    {
        public PartnerMap()
        {
            Table("Partner");

            Map(p => p.CompanyName);
            Map(p => p.Description);
            Map(p => p.CompanyEmailAddress);
            Map(p => p.CompanyPhone);
            Map(p => p.Image);
            Map(p => p.JoinDate);
            Map(p => p.Type).CustomType<int>();
            Map(p => p.IsActive);

            HasMany<Address>(p => p.CompanyAddess)
                   .Table("[Address]")
                   .KeyColumn("Address_ID")
                   .Cascade.AllDeleteOrphan();
        }
    }
}
