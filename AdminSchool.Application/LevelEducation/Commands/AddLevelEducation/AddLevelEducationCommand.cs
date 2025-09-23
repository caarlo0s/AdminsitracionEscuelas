using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.LevelEducation.Commands.AddLevelEducation
{
    public class AddLevelEducationCommand :IRequest<bool>
    {
        public string Name { get; set; }
    }
}
