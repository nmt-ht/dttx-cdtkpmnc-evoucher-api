using eVoucher.Domain.Models;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.Serivces
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(Guid id);
        Task<UserDto> CreateUser(UserDto user);
        Task<UserDto> UpdateUser(UserDto UserDto);
        Task<bool> DeleteUser(Guid id);
        Task<UserDto> UserLogin(UserDto UserDto);
        Task<bool> EditAddress(AddressDto addressDto);
        Task<bool> DeleteAddress(Guid id);
    }
}
