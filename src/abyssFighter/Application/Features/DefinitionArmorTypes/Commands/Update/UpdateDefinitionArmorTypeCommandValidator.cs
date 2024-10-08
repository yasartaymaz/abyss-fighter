using FluentValidation;

namespace Application.Features.DefinitionArmorTypes.Commands.Update;

public class UpdateDefinitionArmorTypeCommandValidator : AbstractValidator<UpdateDefinitionArmorTypeCommand>
{
    public UpdateDefinitionArmorTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.HeroClassId).NotEmpty();
    }
}