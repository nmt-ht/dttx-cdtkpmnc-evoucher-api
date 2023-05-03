namespace eVoucherApi.Models
{
    public class CampaignUser 
    {
        public Guid ID { get; set; }
        public DateTime JoinDate { get; set; }
        public Guid User_ID { get; set; }
        public Guid Campaign_ID { get; set; }
    }
}
