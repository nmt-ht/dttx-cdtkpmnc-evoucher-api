using eVoucher.Service.Dtos;
using eVoucherApi.Models;

namespace eVoucher.Services.Api.Application.Queries;
public interface IGameQueries
{
    Task<IList<GameDto>> GetGames();
}
