using FluentValidation;

namespace Application.Features.DefinitionWalletTypes.Commands.Create;

public class CreateDefinitionWalletTypeCommandValidator : AbstractValidator<CreateDefinitionWalletTypeCommand>
{
    public CreateDefinitionWalletTypeCommandValidator()
    {
    }
}