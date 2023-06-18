using eVoucher.Domain.Models;
using static eVoucher.Domain.Models.DataType;

namespace eVoucher.Service.Dtos
{
    public class PartnerDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CompanyEmailAddress { get; set; } = string.Empty;
        public string CompanyPhone { get; set; } = string.Empty;
        public IList<AddressDto>? CompanyAddess { get; set; } = new List<AddressDto>();
        public byte[]? Image { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.MinValue;
        public ePartnerType Type { get; set; }
        public bool IsActive { get; set; }
        public Guid User_ID_FK { get; set; }
        public IList<PartnerCampaignDto> PartnerCampaigns { get; set; } = new List<PartnerCampaignDto>();
    }
}
