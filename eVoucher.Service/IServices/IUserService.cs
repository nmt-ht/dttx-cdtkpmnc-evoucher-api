using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.Serivces
{
    public interface IUserService
    {
        Task<User> GetUserById(Guid id);
        Task<User> UpdateUser(UserDto UserDto);
        Task<bool> DeleteUser(Guid id);
        User UserLogin(UserDto UserDto);
    }
}
