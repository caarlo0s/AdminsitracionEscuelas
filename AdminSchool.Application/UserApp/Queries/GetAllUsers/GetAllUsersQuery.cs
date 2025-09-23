using AdminSchool.Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.UserApp.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<PagedResultDto<UserListDto>>
    {
           public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
