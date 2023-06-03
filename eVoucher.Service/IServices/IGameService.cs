using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.Serivces
{
    public interface IGameService
    {
        Task<GameDto> GetGameById(Guid id);
        Task<bool> UpdateGame(GameDto gameDto);
        Task<bool> DeleteGame(Guid id);
    }
}
