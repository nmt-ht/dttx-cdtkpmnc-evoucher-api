using eVoucher.Domain.Models;

namespace eVoucher.Infrastructure.Maps
{
    public class VoucherMap : EntityMap<Voucher>
    {
        public VoucherMap()
        {
            Table("Voucher");

            Map(p => p.Name);
            Map(p => p.Code);
            Map(p => p.CreatedDate);
            Map(p => p.AppliedDate);
            Map(p => p.ExpiredDate);
            Map(p => p.Type).CustomType<int>();
            Map(p => p.LimitAmount);
            Map(p => p.Quantity);
            Map(p => p.IsActive);
        }
    }
}
