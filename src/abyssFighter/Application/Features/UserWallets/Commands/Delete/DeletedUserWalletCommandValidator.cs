using FluentValidation;

namespace Application.Features.UserWallets.Commands.Delete;

public class DeleteUserWalletCommandValidator : AbstractValidator<DeleteUserWalletCommand>
{
    public DeleteUserWalletCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}