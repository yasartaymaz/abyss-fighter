using FluentValidation;

namespace Application.Features.UserWallets.Commands.Update;

public class UpdateUserWalletCommandValidator : AbstractValidator<UpdateUserWalletCommand>
{
    public UpdateUserWalletCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.DefinitionWalletTypeId).NotEmpty();
    }
}