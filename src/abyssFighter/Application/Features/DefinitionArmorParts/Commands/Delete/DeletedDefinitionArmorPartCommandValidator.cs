using FluentValidation;

namespace Application.Features.DefinitionArmorParts.Commands.Delete;

public class DeleteDefinitionArmorPartCommandValidator : AbstractValidator<DeleteDefinitionArmorPartCommand>
{
    public DeleteDefinitionArmorPartCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}