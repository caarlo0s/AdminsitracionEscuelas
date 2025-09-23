using AdminSchool.Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.Auth.Command.Login
{
    public class AuthLoginCommand:IRequest<UserInfoDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
