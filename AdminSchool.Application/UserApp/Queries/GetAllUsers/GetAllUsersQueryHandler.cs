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

namespace AdminSchool.Application.UserApp.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler(IUser _userInterface, IMapper _mapper) : IRequestHandler<GetAllUsersQuery, PagedResultDto<UserListDto>>
    {
        public async Task<PagedResultDto<UserListDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var list = await _userInterface.GetAllUsers(request.Page, request.PageSize);
            var resultMapped = _mapper.Map<List<UserListDto>>(list);

            return new PagedResultDto<UserListDto>() {
                Data = resultMapped,
                PageSize = request.PageSize,
                TotalCount = await _userInterface.CountAsync(),
            Page = request.Page
            };
           
        }
    }
}
