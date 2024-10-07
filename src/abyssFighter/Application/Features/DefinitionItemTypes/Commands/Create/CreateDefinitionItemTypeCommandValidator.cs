using FluentValidation;

namespace Application.Features.DefinitionItemTypes.Commands.Create;

public class CreateDefinitionItemTypeCommandValidator : AbstractValidator<CreateDefinitionItemTypeCommand>
{
    public CreateDefinitionItemTypeCommandValidator()
    {
    }
}