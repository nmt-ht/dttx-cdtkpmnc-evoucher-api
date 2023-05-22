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

        public User GetUserById(Guid id)
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

        public User UpdateUser(UserDto userDto)
        {
            try
            {
                var user = _domainRepository.GetOne<User>(u => u.Id == userDto.Id);

                if (user is not null) // update
                {
                    user = _mapper.Map<User>(userDto);
                    _domainRepository.Update(user, true);
                    return user;
                }// add
                else
                {
                    user = _mapper.Map<User>(userDto);
                    _domainRepository.Add(user, true);
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
