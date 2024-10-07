using FluentValidation;

namespace Application.Features.DefinitionArmors.Commands.Create;

public class CreateDefinitionArmorCommandValidator : AbstractValidator<CreateDefinitionArmorCommand>
{
    public CreateDefinitionArmorCommandValidator()
    {
        RuleFor(c => c.DefinitionArmorTypeId).NotEmpty();
        RuleFor(c => c.DefinitionArmorPartId).NotEmpty();
        RuleFor(c => c.DefencePoints).NotEmpty();
    }
}