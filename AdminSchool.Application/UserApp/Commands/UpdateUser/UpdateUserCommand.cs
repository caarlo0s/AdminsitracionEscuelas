using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.UserApp.Commands.UpdateUser
{
    public class UpdateUserCommand :IRequest<int>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CompleteName { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
