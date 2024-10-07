using FluentValidation;

namespace Application.Features.DefinitionArmors.Commands.Delete;

public class DeleteDefinitionArmorCommandValidator : AbstractValidator<DeleteDefinitionArmorCommand>
{
    public DeleteDefinitionArmorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}