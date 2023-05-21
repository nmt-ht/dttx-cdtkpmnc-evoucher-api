using eVoucher.Domain.SeekWork;

namespace eVoucher.Domain.Models
{
    public class Campaign : Entity
    {
        public virtual string? Name { get; set; }
        public virtual string? Description { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime StartedDate { get; set; }
        public virtual DateTime ExpiredDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual User ModifiedBy { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
