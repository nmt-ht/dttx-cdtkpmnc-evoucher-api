﻿using AutoMapper;
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

        public async Task<User> UpdateUser(UpdateUserDto updateUserDto)
        {
            try
            {
                if (updateUserDto is not null)
                {
                    var user = _domainRepository.GetOne<User>(u => u.Id == updateUserDto.Id);

                    //Should be used auto mapper, handle later
                    user.FirstName = updateUserDto.FirstName;
                    user.LastName = updateUserDto.LastName;
                    user.DateOfBirth = updateUserDto.DateOfBirth;
                    user.Phone = updateUserDto.Phone;
                    user.EmailAddress = updateUserDto.EmailAddress;
                    user.Password = updateUserDto.Password;
                    user.UserName = updateUserDto.UserName;

                    _domainRepository.Update(user);
                    return user;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> CreateUser(UserDto userDto)
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

        public async Task<bool> EditAddress(AddressDto addressDto)
        {
            if (addressDto is not null)
            {
                var address = _domainRepository.GetOne<Address>(ad => ad.Id == addressDto.Id);
                address.Street = addressDto.Street;
                address.City = addressDto.City;
                address.Country = addressDto.Country;
                address.District = addressDto.District;
                address.Type = addressDto.Type;
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
    }
}
