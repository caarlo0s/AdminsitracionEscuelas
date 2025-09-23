using AdminSchool.Application.LevelEducation.Commands.AddLevelEducation;
using AdminSchool.Application.UserApp.Commands.AddUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSchool.Application.Common.Validators.Users
{
    public class EducationLevelCommandValidators : AbstractValidator<AddLevelEducationCommand>
    {
        public EducationLevelCommandValidators()
        {
            RuleFor(x => x.Name)
              .Cascade(CascadeMode.Stop)
              .NotEmpty().WithMessage("El nombre es obligatorio.")
              .MinimumLength(3).WithMessage("El nombre de usuario debe tener al menos 3 caracteres.");
        }
    }

    //public class EducationUpdateValidator : AbstractValidator<Update>
    //{
    //    public EducationLevelCommandValidators()
    //    {
    //        RuleFor(x => x.Name)
    //          .Cascade(CascadeMode.Stop)
    //          .NotEmpty().WithMessage("El nombre es obligatorio.")
    //          .MinimumLength(3).WithMessage("El nombre de usuario debe tener al menos 3 caracteres.");
    //    }
    //}
}
