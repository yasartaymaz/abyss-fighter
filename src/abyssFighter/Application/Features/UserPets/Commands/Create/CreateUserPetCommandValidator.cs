using FluentValidation;

namespace Application.Features.UserPets.Commands.Create;

public class CreateUserPetCommandValidator : AbstractValidator<CreateUserPetCommand>
{
    public CreateUserPetCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.DefinitionPetId).NotEmpty();
        RuleFor(c => c.HealthPoints).NotEmpty();
        RuleFor(c => c.AttackPoints).NotEmpty();
        RuleFor(c => c.DefencePoints).NotEmpty();
    }
}