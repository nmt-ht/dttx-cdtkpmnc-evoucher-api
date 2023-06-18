namespace eVoucher.Service.Dtos
{
    public class CampaignUserDto
    {
        public Guid ID { get; set; }
        public DateTime JoinDate { get; set; }
        public Guid UserId { get; set; }
        public Guid CampaignId { get; set; }
    }
}
