using eVoucherApi.Models;

namespace eVoucher.Services.Api.Application.Queries;
public interface IPartnerQueries
{
    Task<IList<Partner>> GetPartners();
}
