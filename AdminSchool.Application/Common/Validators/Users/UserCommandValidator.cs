using AdminSchool.Application.UserApp.Commands.AddUser;
using AdminSchool.Application.UserApp.Commands.UpdateUser;
using FluentValidation;

namespace AdminSchool.Application.Common.Validators.Users
{
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
 
             RuleFor(x => x.UserName)
    .Cascade(CascadeMode.Stop)
    .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
    .MinimumLength(3).WithMessage("El nombre de usuario debe tener al menos 3 caracteres.");

            RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El email es obligatorio.")
                .EmailAddress().WithMessage("Debe ser un email válido.");

            RuleFor(x => x.CompleteName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre completo es obligatorio.")
                .MaximumLength(150).WithMessage("El nombre completo no puede exceder 150 caracteres.");

            RuleFor(x => x.PasswordHash).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("La contraseña es obligatoria.")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.");
        }
    }


    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.UserName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre de usuario es obligatorio.")
                .MinimumLength(3).WithMessage("El nombre de usuario debe tener al menos 3 caracteres.");

            RuleFor(x => x.Email).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El email es obligatorio.")
                .EmailAddress().WithMessage("Debe ser un email válido.");

            RuleFor(x => x.CompleteName).Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre completo es obligatorio.")
                .MaximumLength(150).WithMessage("El nombre completo no puede exceder 150 caracteres.");

            //RuleFor(x => x.PasswordHash).Cascade(CascadeMode.Stop)
            //    .NotEmpty().WithMessage("La contraseña es obligatoria.")
            //    .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres.");
        }
    }
}