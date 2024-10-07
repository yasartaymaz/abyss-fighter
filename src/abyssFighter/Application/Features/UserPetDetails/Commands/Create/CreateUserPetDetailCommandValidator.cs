using FluentValidation;

namespace Application.Features.UserPetDetails.Commands.Create;

public class CreateUserPetDetailCommandValidator : AbstractValidator<CreateUserPetDetailCommand>
{
    public CreateUserPetDetailCommandValidator()
    {
        RuleFor(c => c.UserPetId).NotEmpty();
        RuleFor(c => c.AttackPoints).NotEmpty();
        RuleFor(c => c.DefencePoints).NotEmpty();
    }
}