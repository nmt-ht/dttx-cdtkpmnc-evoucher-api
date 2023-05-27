using eVoucher.Service.Dtos;
using eVoucherApi.Models;

namespace eVoucher.Services.Api.Application.Queries;
public interface IPartnerQueries
{
    Task<IList<PartnerDto>> GetPartners();
}
