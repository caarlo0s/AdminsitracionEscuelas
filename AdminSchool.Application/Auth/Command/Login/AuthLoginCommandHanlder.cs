using AdminSchool.Application.Common.Dtos;
using AdminSchool.Domain.Entities;
using AdminSchool.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.Auth.Command.Login
{
    internal class AuthLoginCommandHanlder (IAuth _iAuth,IMapper _mapper,IJwtService _jwtService): IRequestHandler<AuthLoginCommand, UserInfoDto>
    {
        public async Task<UserInfoDto> Handle(AuthLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _iAuth.LogIn(request.UserName, request.Password);

                if (user == null)
                    throw new UnauthorizedAccessException("Invalid credentials");

                var resultMapped = _mapper.Map<UserInfoDto>(user);

                var roles = user.UserRoles.Select(ur => ur.Role.Name);

                resultMapped.Token= _jwtService.GenerateToken(user.Id.ToString(), user.UserName, roles);

                return resultMapped;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
