using FluentValidation;

namespace Application.Features.DefinitionWeaponTypes.Commands.Delete;

public class DeleteDefinitionWeaponTypeCommandValidator : AbstractValidator<DeleteDefinitionWeaponTypeCommand>
{
    public DeleteDefinitionWeaponTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}