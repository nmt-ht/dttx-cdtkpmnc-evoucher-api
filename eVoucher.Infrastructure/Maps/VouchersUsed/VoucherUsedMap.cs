using eVoucher.Domain.Models;

namespace eVoucher.Infrastructure.Maps
{
    public class VoucherUsedMap : EntityMap<VoucherUsed>
    {
        public VoucherUsedMap()
        {
            Table("VoucherUsed");

            Map(p => p.ReceivedDate);
            Map(p => p.IsUsed);
            Map(p => p.UsedDate);

            References<User>(x => x.User)
            .Column("User_ID_FK");
        }
    }
}