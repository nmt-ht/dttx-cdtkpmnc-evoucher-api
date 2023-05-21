namespace eVoucher.Domain.Models
{
    public class DataType
    {
        public enum eAddressType
        {
            ShipTo = 0,
            BillTo = 1,
            BillToShipTo = 2,
            Company = 3
        }

        public enum ePartnerType
        {
            Food = 0,
            Drink = 1,
            Technology = 2
        }

        public enum eVoucherType
        {
	        ten = 0,
	        twenty = 1,
	        thirty = 2,
	        fifty = 3,
	        onhundered = 4
        }
    }
}
