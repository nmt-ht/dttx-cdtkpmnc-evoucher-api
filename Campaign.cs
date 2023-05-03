using eVoucher.Domain.SeekWork;

namespace eVoucher.Domain.Models
{
    public class Campaign : Entity
    {
        public virtual string? Name { get; set; }
        public virtual string? Description { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime StartedDate { get; set; }
        public virtual DateTime ExpiredDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual string? CreatedBy { get; set; }
    }
}
