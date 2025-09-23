using AdminSchool.Domain.Entities;
using AdminSchool.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.UserApp.Commands.UpdateUser
{
    public class UpdateUserCommandHandler(IUser _userInterface, ILogger<UpdateUserCommandHandler> _logger) : IRequestHandler<UpdateUserCommand, int>
    {
        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userInterface.GetByIdAsync(request.Id);
            if (user is not null)
            {
                var updatedUser = user.Update(request.UserName, request.Email, request.CompleteName, request.Password);
                await _userInterface.UpdateAsync(user);
                return 1;
            }
            else
            {
                throw new Exception("El usuario no se encuentra registrado");

            }


        }
    }
}
