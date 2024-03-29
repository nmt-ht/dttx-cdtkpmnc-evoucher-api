﻿using eVoucher.Service.Dtos;
using MediatR;

namespace eVoucherApi.Application.Commands
{
    public class GetUserCommand : IRequest<UserDto>
    {
        public Guid Id { get; set; }
        public GetUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
