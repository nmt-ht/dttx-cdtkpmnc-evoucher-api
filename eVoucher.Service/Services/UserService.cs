using AutoMapper;
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

        public async Task<bool> UpdateUser(CreateUserDto createUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
