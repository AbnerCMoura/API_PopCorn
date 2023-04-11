using FluentValidation;
using PopCornAndCritics.Models.DTOs;

namespace PopCornAndCritics.Models.Validators;

public class UserSigIntValidator : AbstractValidator<UserSigInDTO>
{
    public UserSigIntValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("O e-mail precisa ser preencido.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("A senha precisa ser preenchida.");
    }
}
