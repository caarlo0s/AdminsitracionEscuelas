using AdminSchool.Domain.Entities;
using AdminSchool.Domain.Interfaces;
using AutoMapper;
using BCrypt.Net;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.UserApp.Commands.AddUser
{
    public class AddUserCommandHandler(IUser _userInterface, ILogger<AddUserCommandHandler> _logger , IMapper _mapper) : IRequestHandler<AddUserCommand, bool>
    {
        public async Task<bool> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
			try
			{
                var exist =await  _userInterface.GetUserByUserName(request.UserName);
                if (exist is not null) 
                {
                    throw new Exception("El username: " + request.UserName + " ya se encuentra registrado");
                }
              
                var user = Users.Create(request.UserName, request.Email, request.CompleteName, BCrypt.Net.BCrypt.HashPassword(request.PasswordHash), true);

                await _userInterface.AddAsync(user);

                return true;
   
            }
			catch (Exception ex)
			{

                _logger.LogError("Error al ingresar usaurio: UserCommandHanlder: " +ex.Message);
                throw new Exception("Error al ingresar usuario");
			}
        }
    }
}
