using eVoucher.Domain.SeekWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eVoucher.Domain.Models.DataType;

namespace eVoucher.Domain.Models
{
    public class Voucher : Entity
    {
        public virtual string? Name { get; set; }
        public virtual string? Code { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime AppliedDate { get; set; }
        public virtual DateTime ExpiredDate { get; set; }
        public virtual eVoucherType Type { get; set; }
        public virtual Decimal LimitAmount { get; set; }
        public virtual int? Quantity { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
