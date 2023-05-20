namespace eVoucher.Service.Dtos
{
    public class CampaignDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.MinValue;
        public DateTime StartedDate { get; set; } = DateTime.MinValue;
        public DateTime ExpiredDate { get; set; } = DateTime.MinValue;
        public DateTime ModifiedDate { get; set; } = DateTime.MinValue;
        public UserDto ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public UserDto CreatedBy { get; set; }
    }
}
