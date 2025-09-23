using AdminSchool.Application.Common.Dtos;
using AdminSchool.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQuery:IRequest<PagedResultDto<GetAllStudentsDto>>
    {
        public string? SearchText { get; set; }
        public int? GradeId { get; set; }
        public int? GroupId { get; set; }

        public int Page { get;set; }
        public int PageSize { get; set; }
    }
}
