using AutoMapper;
using eVoucher.Domain.Models;
using eVoucher.Infrastructure.Reposistories;
using eVoucher.Service.Dtos;

namespace eVoucher.Service.Serivces
{
    public class UserService : IUserService
    {
        private readonly IDomainRepository _domainRepository;
        private readonly IMapper _mapper;

        public UserService(IDomainRepository domainRepository, IMapper mapper)
        {
            _domainRepository = domainRepository;
            _mapper = mapper;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = _domainRepository.GetOne<User>(c => c.Id == id);
            return user;
        }

        public User UserLogin(UserDto userDto)
        {
            var user = _domainRepository.GetOne<User>(c => c.EmailAddress == userDto.EmailAddress && c.Password == userDto.Password);
            return user;
        }
        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                var user = _domainRepository.GetOne<User>(u => u.Id == id);

                if (user is not null) // delete 
                {
                    _domainRepository.Remove(user, true);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> UpdateUser(UserDto userDto)
        {
            try
            {
                if(userDto.Id == Guid.Empty)
                {
                    var user = _mapper.Map<UserDto, User>(userDto);
                    _domainRepository.AddOrUpdate(user);
                    _domainRepository.Refresh(user);

                    foreach (var address in userDto.Addresses)
                    {
                        var addressObject = _mapper.Map<AddressDto, Address>(address);
                        addressObject.User = user;

                        if (user.Addresses is null)
                            user.Addresses = new List<Address>();

                        user.Addresses.Add(addressObject);
                    }
                    _domainRepository.AddOrUpdate(user);
                    return user;
                }
                else
                {
                    var user = _domainRepository.GetOne<User>(u => u.Id == userDto.Id);
                    user = _mapper.Map<UserDto, User>(userDto);

                    if(user.Addresses is not null)
                        user.Addresses.Clear();

                    foreach (var address in userDto.Addresses)
                    {
                        var addressObject = _mapper.Map<AddressDto, Address>(address);
                        addressObject.User = user;

                        if (user.Addresses is null)
                            user.Addresses = new List<Address>();

                        user.Addresses.Add(addressObject);
                    }
                    _domainRepository.Update(user);
                    return user;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
