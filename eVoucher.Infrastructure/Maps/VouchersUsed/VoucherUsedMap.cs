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
        }
    }
}
