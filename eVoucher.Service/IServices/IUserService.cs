using eVoucher.Service.Dtos;

namespace eVoucher.Service.Serivces
{
    public interface IUserService
    {
        Task<bool> UpdateUser(UserDto UserDto);
        Task<bool> DeleteUser(Guid id);
    }
}
