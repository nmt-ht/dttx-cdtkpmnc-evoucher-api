namespace eVoucher.Service.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string EmailAddress { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public IList<AddressDto> Addresses { get; set; } = new List<AddressDto>();
        public IList<UserGroupDto> UserGroups { get; set; } = new List<UserGroupDto>();
    }
}
