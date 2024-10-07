using FluentValidation;

namespace Application.Features.UserPets.Commands.Delete;

public class DeleteUserPetCommandValidator : AbstractValidator<DeleteUserPetCommand>
{
    public DeleteUserPetCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}