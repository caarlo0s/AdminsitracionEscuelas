using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.UserApp.Commands.AddUser
{
    public class AddUserCommand : IRequest<bool>
    {
     
        public string UserName { get;  set; }
        public string Email { get;  set; }
        public string CompleteName { get;  set; }
        public string PasswordHash { get;  set; } = string.Empty;
    }
}
