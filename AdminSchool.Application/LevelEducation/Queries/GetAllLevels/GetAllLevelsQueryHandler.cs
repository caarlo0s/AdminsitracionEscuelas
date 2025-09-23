using AdminSchool.Application.Common.Dtos;
using AdminSchool.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.LevelEducation.Queries.GetAllLevels
{
    public class GetAllLevelsQueryHandler(IEducationLevel _educationLevelInterface, IMapper _mapper) :
        IRequestHandler<GetAllLevelsQuery, PagedResultDto<GetAllEducationLevelsDto>>
    {
        public async Task<PagedResultDto<GetAllEducationLevelsDto>> Handle(GetAllLevelsQuery request, CancellationToken cancellationToken)
        {
            var list = await _educationLevelInterface.GetAllPaginatedEducationLevel(request.Page, request.PageSize, request.SearchText);

            var resultMapped = _mapper.Map<List<GetAllEducationLevelsDto>>(list);


            return new PagedResultDto<GetAllEducationLevelsDto>()
            {
                Data = resultMapped,
                PageSize = request.PageSize,
                TotalCount = await _educationLevelInterface.CountAsync(),
                Page = request.Page
            };
        }
    }
}
