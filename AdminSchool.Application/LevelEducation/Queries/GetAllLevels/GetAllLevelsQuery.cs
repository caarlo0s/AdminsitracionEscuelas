using AdminSchool.Application.Common.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.LevelEducation.Queries.GetAllLevels
{
    public class GetAllLevelsQuery : IRequest<PagedResultDto<GetAllEducationLevelsDto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchText { get; set; }
    }
}
