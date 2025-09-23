using AdminSchool.Application.Common.Dtos;
using AdminSchool.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.Students.Queries.GetAllStudents
{
    public class GetAllStudentsQueryHandler(IStudent _studentInterface, IMapper _mapper) : IRequestHandler<GetAllStudentsQuery, PagedResultDto<GetAllStudentsDto>>
    {
        public async Task<PagedResultDto<GetAllStudentsDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var listUsers = await _studentInterface.GetAllStudents(request.Page, request.PageSize, request.GradeId, request.GroupId, request.SearchText);
            var resultMapped = _mapper.Map<List<GetAllStudentsDto>>(listUsers);
            return new PagedResultDto<GetAllStudentsDto>()
            {
                Data = resultMapped,
                PageSize = request.PageSize,
                TotalCount = await _studentInterface.CountAsync(),
                Page = request.Page
            };
        }
    }
}
