using AdminSchool.Domain.Entities;
using AdminSchool.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.LevelEducation.Commands.AddLevelEducation
{
    public class AddLevelEducationCommandHandler(ILogger<AddLevelEducationCommandHandler> _logger, IEducationLevel _educationLevelInterface) : IRequestHandler<AddLevelEducationCommand, bool>
    {
        public async Task<bool> Handle(AddLevelEducationCommand request, CancellationToken cancellationToken)
        {
			try
			{
				var education = EducationLevel.Create(request.Name);
				 await  _educationLevelInterface.AddAsync(education);
                return true;
			}
			catch (Exception ex)
			{

                _logger.LogError("Error al ingresar usaurio: UserCommandHanlder: " + ex.Message);
                throw new Exception("Error al ingresar Nivel de educación");
            }
        }
    }
}
