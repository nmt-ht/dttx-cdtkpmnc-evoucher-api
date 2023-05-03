using eVoucher.Domain.SeekWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.Domain.Models
{
    public class VoucherUsed : Entity
    {
        public virtual DateTime ReceivedDate { get; set; }
        public virtual bool IsUsed { get; set; }
        public virtual DateTime UsedDate { get; set; }
        
        
    }
}
