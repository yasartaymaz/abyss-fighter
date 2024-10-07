using FluentValidation;

namespace Application.Features.DefinitionItems.Commands.Update;

public class UpdateDefinitionItemCommandValidator : AbstractValidator<UpdateDefinitionItemCommand>
{
    public UpdateDefinitionItemCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.DefinitionItemTypeId).NotEmpty();
        RuleFor(c => c.ItemId).NotEmpty();
        RuleFor(c => c.IsStackable).NotEmpty();
        RuleFor(c => c.IsWeapon).NotEmpty();
        RuleFor(c => c.IsArmor).NotEmpty();
    }
}