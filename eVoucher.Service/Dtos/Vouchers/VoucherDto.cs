﻿using static eVoucher.Domain.Models.DataType;

namespace eVoucher.Service.Dtos
{
    public class VoucherDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? AppliedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public int Quantity { get; set; }
        public int LimitAmount { get; set; }
        public bool IsActive { get; set; }
        public eVoucherType Type { get; set; }
        public Guid Game_ID_FK { get; set; }
        public Guid User_ID_FK { get; set; }
    }
}
