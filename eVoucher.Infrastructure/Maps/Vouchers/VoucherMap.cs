using eVoucher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Map(p => p.Type);
            Map(p => p.LimitAmount);
            Map(p => p.Quantity);
            Map(p => p.IsActive);
        }
    }
}
