using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.Serivces
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(Guid id);
        Task<User> CreateUser(UserDto user);
        Task<User> UpdateUser(UpdateUserDto UserDto);
        Task<bool> DeleteUser(Guid id);
        Task<UserDto> UserLogin(UserDto UserDto);
        Task<bool> EditAddress(AddressDto addressDto);
        Task<bool> DeleteAddress(Guid id);
    }
}
