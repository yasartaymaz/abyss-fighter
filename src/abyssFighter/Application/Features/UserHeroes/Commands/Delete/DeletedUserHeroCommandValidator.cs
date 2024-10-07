using FluentValidation;

namespace Application.Features.UserHeroes.Commands.Delete;

public class DeleteUserHeroCommandValidator : AbstractValidator<DeleteUserHeroCommand>
{
    public DeleteUserHeroCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}