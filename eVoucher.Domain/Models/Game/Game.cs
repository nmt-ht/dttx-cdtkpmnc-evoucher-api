using eVoucher.Domain.Models;
using eVoucher.Domain.SeekWork;
namespace eVoucher.Domain.Models
{
    public class Game : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual User ModifiedBy { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual byte[]? Image { get; set; }
        public virtual IList<CampaignGame> CampaignGames { get; set; }

    }
}