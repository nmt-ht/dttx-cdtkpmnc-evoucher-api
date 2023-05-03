namespace eVoucherApi.Models
{
    public class Campaign
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime ExpiredDate { get; set; }        
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
