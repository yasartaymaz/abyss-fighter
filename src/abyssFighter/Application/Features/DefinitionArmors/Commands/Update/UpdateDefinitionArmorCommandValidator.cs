using FluentValidation;

namespace Application.Features.DefinitionArmors.Commands.Update;

public class UpdateDefinitionArmorCommandValidator : AbstractValidator<UpdateDefinitionArmorCommand>
{
    public UpdateDefinitionArmorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.DefinitionArmorTypeId).NotEmpty();
        RuleFor(c => c.DefinitionArmorPartId).NotEmpty();
        RuleFor(c => c.DefencePoints).NotEmpty();
    }
}