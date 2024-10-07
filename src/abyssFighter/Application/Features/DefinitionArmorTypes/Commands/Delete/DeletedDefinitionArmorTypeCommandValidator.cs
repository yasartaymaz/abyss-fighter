using FluentValidation;

namespace Application.Features.DefinitionArmorTypes.Commands.Delete;

public class DeleteDefinitionArmorTypeCommandValidator : AbstractValidator<DeleteDefinitionArmorTypeCommand>
{
    public DeleteDefinitionArmorTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}