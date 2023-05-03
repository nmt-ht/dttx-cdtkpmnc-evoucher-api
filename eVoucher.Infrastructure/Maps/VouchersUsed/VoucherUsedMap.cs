using eVoucher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
