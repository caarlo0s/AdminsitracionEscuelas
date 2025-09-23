using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.Students.Commands.AddStudent
{
    public class AddStudentCommand :IRequest<bool>
    {
    }
}
