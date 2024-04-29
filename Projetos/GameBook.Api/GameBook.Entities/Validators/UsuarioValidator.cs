using FluentValidation;
using GameBook.Entities.Usuario;

namespace GameBook.Entities.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioRequest>
    {
        public UsuarioValidator()
        {
            RuleFor(Usuario => Usuario.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MinimumLength(2).WithMessage("O nome precisa ter mais de 2 caracteres.")
                .MaximumLength(500).WithMessage("O nome não pode passar de 500 caracteres.");

            RuleFor(Usuario => Usuario.Documento)
                .NotEmpty().WithMessage("O documento é obrigatório.")
                .MinimumLength(11).WithMessage("O documento precisa no minimo 11 digitos.")
                .MaximumLength(14).WithMessage("O documento pode ter no maximo 14 digitos.");

            RuleFor(Usuario => Usuario.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email informado não é válido. Por favor, insira um email válido.");
        }
    }
}
