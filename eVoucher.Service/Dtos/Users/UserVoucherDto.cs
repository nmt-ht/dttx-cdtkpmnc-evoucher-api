namespace eVoucher.Service.Dtos
{
    public class UserVoucherDto
    {
        public string VoucherCode { get; set; }
        public string ReceivedDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string GameName { get; set; }
        public string CampaignName { get; set; }
        public bool IsActive { get; set; }
    }
}
