namespace eVoucher.Domain.Models
{
    public class DataType
    {
        public enum eAddressType
        {
            ShipTo = 0,
            BillTo = 1,
            BillToShipTo = 2
        }
    }
}
