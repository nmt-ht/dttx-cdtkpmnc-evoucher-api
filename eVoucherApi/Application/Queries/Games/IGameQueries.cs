using eVoucher.Service.Dtos;

namespace eVoucher.Services.Api.Application.Queries;
public interface IGameQueries
{
    Task<IList<GameDto>> GetGames();
}
