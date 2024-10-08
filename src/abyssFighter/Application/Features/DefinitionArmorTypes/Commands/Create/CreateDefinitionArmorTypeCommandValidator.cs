using FluentValidation;

namespace Application.Features.DefinitionArmorTypes.Commands.Create;

public class CreateDefinitionArmorTypeCommandValidator : AbstractValidator<CreateDefinitionArmorTypeCommand>
{
    public CreateDefinitionArmorTypeCommandValidator()
    {
        RuleFor(c => c.HeroClassId).NotEmpty();
    }
}