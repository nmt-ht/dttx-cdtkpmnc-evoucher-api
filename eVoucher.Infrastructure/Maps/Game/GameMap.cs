using eVoucher.Domain.Models;
using eVoucherApi.domain.Models;

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

            References<User>(x => x.CreatedBy)
             .Column("CreatedBy");

            References<User>(x => x.ModifiedBy)
                .Column("ModifiedBy");
        }
    }
}
