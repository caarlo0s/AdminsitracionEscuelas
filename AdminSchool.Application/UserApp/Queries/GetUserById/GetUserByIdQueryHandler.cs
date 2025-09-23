using AdminSchool.Application.Common.Dtos;
using AdminSchool.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.UserApp.Queries.GetUserById
{
    public class GetUserByIdQueryHandler(IUser _userInterface, IMapper _mapper) : IRequestHandler<GetUserByIdQuery, UserUpdateInfo>
    {
        public async Task<UserUpdateInfo> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
           
            var user =await _userInterface.GetByIdAsync(request.Id, cancellationToken);
      
              return _mapper.Map<UserUpdateInfo>(user);   
            }
    }
}
