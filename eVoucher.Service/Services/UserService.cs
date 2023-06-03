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

        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = _domainRepository.GetOne<User>(c => c.Id == id);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> UserLogin(UserDto userDto)
        {
            var user = _domainRepository.GetOne<User>(c => c.EmailAddress == userDto.EmailAddress && c.Password == userDto.Password);
            return _mapper.Map<User, UserDto>(user);
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
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            try
            {
                if (userDto is not null)
                {
                    var user = new User();
                    if (userDto.Id != Guid.Empty)
                    {
                        user = _domainRepository.Get<User>(userDto.Id);
                        if (user is not null)
                        {
                            // Update addresses
                            if (userDto.Addresses is not null && userDto.Addresses.Any())
                            {
                                foreach (var addressDto in userDto.Addresses)
                                {
                                    var existingAddress = user.Addresses.FirstOrDefault(a => a.Id == addressDto.Id);
                                    if (existingAddress is not null)
                                    {
                                        _mapper.Map(addressDto, existingAddress);
                                    }
                                    else
                                    {
                                        var newAddress = _mapper.Map<Address>(addressDto);
                                        newAddress.User = user;
                                        user.Addresses.Add(newAddress);
                                    }
                                }
                            }
                            else if (user.Addresses is not null && user.Addresses.Any())
                            {
                                user.Addresses.Clear();
                            }

                            // Update user groups
                            if (userDto.UserGroups is not null && userDto.UserGroups.Any())
                            {
                                foreach (var userGroupDto in userDto.UserGroups)
                                {
                                    var existingUserGroup = user.UserGroups.FirstOrDefault(ug => ug.Id == userGroupDto.Id);
                                    if (existingUserGroup is not null)
                                    {
                                        _mapper.Map(userGroupDto, existingUserGroup);
                                    }
                                    else
                                    {
                                        var newUserGroup = _domainRepository.GetOne<UserGroup>(x => x.Id == userGroupDto.Id);
                                        var userGroupLink = new UserGroupLink
                                        {
                                            User = user,
                                            UserGroup = newUserGroup
                                        };
                                        _domainRepository.AddOrUpdate(userGroupLink);
                                    }
                                }
                            }
                            else if (user.UserGroups is not null && user.UserGroups.Any())
                            {
                                user.UserGroups.Clear();
                            }

                            _domainRepository.AddOrUpdate(user);
                        }
                    }
                    else // Create new user
                    {
                        user = _mapper.Map<UserDto, User>(userDto);
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
                        _domainRepository.Refresh(user);

                        foreach (var userGroupDto in userDto.UserGroups)
                        {
                            var userGroup = _domainRepository.GetOne<UserGroup>(x => x.Id == userGroupDto.Id);

                            var userGroupLink = new UserGroupLink
                            {
                                User = user,
                                UserGroup = userGroup
                            };

                            _domainRepository.AddOrUpdate(userGroupLink);
                        }
                    }

                    return _mapper.Map<User, UserDto>(user);
                }

                return null;
            }
            catch (Exception ex)
            {
                // Handle exception
                throw;
            }
        }

        public async Task<bool> EditAddress(AddressDto addressDto)
        {
            if (addressDto is not null)
            {
                var address = _mapper.Map<AddressDto, Address>(addressDto);

                // Set the User property
                var user = _domainRepository.GetOne<User>(u => u.Id == addressDto.UserId);
                address.User = user;

                _domainRepository.Update(address);
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAddress(Guid id)
        {
            try
            {
                var user = _domainRepository.GetOne<Address>(u => u.Id == id);

                if (user is not null) // delete 
                {
                    _domainRepository.Remove(user, true);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CheckUser(string email)
        {
            try
            {
                var user = _domainRepository.GetOne<User>(u => u.EmailAddress == email);

                if (user is not null)  
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
