﻿using eVoucher.Service.Serivces;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class CreateUpdateUserCommandHandler : IRequestHandler<CreateUpdateUserCommand, bool>
    {
        private readonly IUserService _userService;

        public CreateUpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(CreateUpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (request is null) return false;
            return await _userService.UpdateUser(request.UserDto);
        }
    }
}