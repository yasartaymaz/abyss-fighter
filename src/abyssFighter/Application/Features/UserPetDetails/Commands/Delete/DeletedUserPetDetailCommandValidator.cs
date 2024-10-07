using FluentValidation;

namespace Application.Features.UserPetDetails.Commands.Delete;

public class DeleteUserPetDetailCommandValidator : AbstractValidator<DeleteUserPetDetailCommand>
{
    public DeleteUserPetDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}