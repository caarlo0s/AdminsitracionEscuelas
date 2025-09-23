using AdminSchool.Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.UserApp.Queries.GetUserById
{
    public class GetUserByIdQuery :IRequest<UserUpdateInfo>
    {
        public Guid Id { get; set; }    
    }
}
