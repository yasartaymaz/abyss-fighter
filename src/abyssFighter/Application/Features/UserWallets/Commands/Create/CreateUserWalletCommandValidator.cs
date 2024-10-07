using FluentValidation;

namespace Application.Features.UserWallets.Commands.Create;

public class CreateUserWalletCommandValidator : AbstractValidator<CreateUserWalletCommand>
{
    public CreateUserWalletCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.DefinitionWalletTypeId).NotEmpty();
    }
}