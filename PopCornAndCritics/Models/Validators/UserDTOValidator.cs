using FluentValidation;
using PopCornAndCritics.Models.DTOs;

namespace PopCornAndCritics.Models.Validators;
public class UserDTOValidator : AbstractValidator<UserDTO>
{
    public UserDTOValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("O campo 'UserName' é obrigatório.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("O campo 'Password' é obrigatório.");
        RuleFor(x => x.Email).NotEmpty().WithMessage("O campo 'Email' é obrigatório.");
        RuleFor(x => x.Email).EmailAddress().WithMessage("O campo 'Email' não é um endereço de e-mail válido.");
    }
}

