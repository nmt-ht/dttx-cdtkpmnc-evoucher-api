using eVoucher.Domain.Models;

namespace eVoucher.Infrastructure.Maps
{
    public class GameMap : EntityMap<Game>
    {
        public  GameMap()
        {
            Table("Game");

            Map(p => p.Name);
            Map(p => p.Description);
            Map(p => p.CreatedDate);
            Map(p => p.ModifiedDate);
            Map(p => p.IsDeleted);
            Map(p => p.Image).CustomSqlType("VARBINARY(MAX)").Length(int.MaxValue);

            HasMany(p => p.CampaignGames)
                   .KeyColumn("Game_ID_FK")
                   .Inverse()
                   .Cascade.AllDeleteOrphan();

            References<User>(x => x.CreatedBy)
             .Column("CreatedBy");

            References<User>(x => x.ModifiedBy)
                .Column("ModifiedBy");
        }
    }
}
