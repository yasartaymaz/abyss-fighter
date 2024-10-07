using FluentValidation;

namespace Application.Features.UserPetDetails.Commands.Update;

public class UpdateUserPetDetailCommandValidator : AbstractValidator<UpdateUserPetDetailCommand>
{
    public UpdateUserPetDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserPetId).NotEmpty();
        RuleFor(c => c.AttackPoints).NotEmpty();
        RuleFor(c => c.DefencePoints).NotEmpty();
    }
}