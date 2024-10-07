using FluentValidation;

namespace Application.Features.DefinitionWeapons.Commands.Delete;

public class DeleteDefinitionWeaponCommandValidator : AbstractValidator<DeleteDefinitionWeaponCommand>
{
    public DeleteDefinitionWeaponCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}