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

        public async Task<bool> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUser(UserDto userDto)
        {
            try
            {
                var user = _domainRepository.GetOne<User>(u => u.Id == userDto.Id);

                if (user is not null) // update
                {
                    user = _mapper.Map<User>(userDto);
                    _domainRepository.Update(user, true);
                    return true;
                }// add
                else
                {
                    user = _mapper.Map<User>(userDto);
                    _domainRepository.Add(user, true);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
