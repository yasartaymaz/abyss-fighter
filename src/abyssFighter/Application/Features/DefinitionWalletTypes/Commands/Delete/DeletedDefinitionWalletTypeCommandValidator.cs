using FluentValidation;

namespace Application.Features.DefinitionWalletTypes.Commands.Delete;

public class DeleteDefinitionWalletTypeCommandValidator : AbstractValidator<DeleteDefinitionWalletTypeCommand>
{
    public DeleteDefinitionWalletTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}