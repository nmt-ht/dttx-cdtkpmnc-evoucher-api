using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.Serivces
{
    public interface IUserService
    {
        User GetUserById(Guid id);
        Task<bool> UpdateUser(UserDto UserDto);
        Task<bool> DeleteUser(Guid id);
    }
}
