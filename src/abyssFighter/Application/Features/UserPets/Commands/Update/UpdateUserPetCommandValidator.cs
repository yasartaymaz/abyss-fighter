using FluentValidation;

namespace Application.Features.UserPets.Commands.Update;

public class UpdateUserPetCommandValidator : AbstractValidator<UpdateUserPetCommand>
{
    public UpdateUserPetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.DefinitionPetId).NotEmpty();
        RuleFor(c => c.HealthPoints).NotEmpty();
        RuleFor(c => c.AttackPoints).NotEmpty();
        RuleFor(c => c.DefencePoints).NotEmpty();
    }
}