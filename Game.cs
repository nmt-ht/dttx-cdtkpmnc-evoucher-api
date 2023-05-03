using eVoucher.Domain.SeekWork;
namespace eVoucherApi.domain.Models
{
    public class Game : Entity
    {
        public virtual string? Name { get; set; }
        public virtual string? Description { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}