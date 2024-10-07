using FluentValidation;

namespace Application.Features.UserHeroes.Commands.Create;

public class CreateUserHeroCommandValidator : AbstractValidator<CreateUserHeroCommand>
{
    public CreateUserHeroCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.DefinitionHeroClassId).NotEmpty();
    }
}