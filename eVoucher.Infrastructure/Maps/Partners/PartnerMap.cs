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
            Map(p => p.Image).CustomSqlType("VARBINARY(MAX)").Length(int.MaxValue);
            Map(p => p.JoinDate);
            Map(p => p.Type).CustomType<int>();
            Map(p => p.IsActive);

            HasMany(p => p.PartnerCampaigns)
                   .KeyColumn("Partner_ID_FK")
                   .Inverse()
                   .Cascade.AllDeleteOrphan();

            References<User>(x => x.User)
               .Column("User_ID_FK");
        }
    }
}
