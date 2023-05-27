﻿using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.Serivces
{
    public interface IPartnerService
    {
        Task<PartnerDto> GetPartnerById(Guid id);
        Task<bool> UpdatePartner(PartnerDto PartnerDto);
        Task<bool> DeletePartner(Guid id);
    }
}
