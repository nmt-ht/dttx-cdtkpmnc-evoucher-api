using eVoucher.Domain.SeekWork;

namespace eVoucher.Domain.Models
{
    public class VoucherUsed : Entity
    {
        public virtual DateTime ReceivedDate { get; set; }
        public virtual bool IsUsed { get; set; }
        public virtual DateTime UsedDate { get; set; }
    }
}
