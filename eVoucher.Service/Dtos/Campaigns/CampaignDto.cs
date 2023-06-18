
namespace eVoucher.Service.Dtos
{
    public class CampaignDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public byte[]? Image { get; set; }
        public Guid PartnerId { get; set; }
        public IList<PartnerDto> Partners { get; set; } = new List<PartnerDto>();
        public IList<GameDto>? Games { get; set; } = new List<GameDto>();
        public string UserName { get; set; }
    }
}
