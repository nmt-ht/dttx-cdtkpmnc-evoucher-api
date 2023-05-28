using static eVoucher.Domain.Models.DataType;

namespace eVoucher.Service.Dtos
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public eAddressType Type { get; set; }
        public Guid UserId { get; set; }
    }
}
