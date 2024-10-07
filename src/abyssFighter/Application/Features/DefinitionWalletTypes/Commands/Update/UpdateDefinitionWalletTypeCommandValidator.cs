using FluentValidation;

namespace Application.Features.DefinitionWalletTypes.Commands.Update;

public class UpdateDefinitionWalletTypeCommandValidator : AbstractValidator<UpdateDefinitionWalletTypeCommand>
{
    public UpdateDefinitionWalletTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}