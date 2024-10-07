using FluentValidation;

namespace Application.Features.DefinitionItemTypes.Commands.Update;

public class UpdateDefinitionItemTypeCommandValidator : AbstractValidator<UpdateDefinitionItemTypeCommand>
{
    public UpdateDefinitionItemTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}