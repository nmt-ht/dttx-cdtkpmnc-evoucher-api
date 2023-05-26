namespace eVoucher.Service.Dtos
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
