using FluentValidation;

namespace Application.Features.UserHeroes.Commands.Update;

public class UpdateUserHeroCommandValidator : AbstractValidator<UpdateUserHeroCommand>
{
    public UpdateUserHeroCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.DefinitionHeroClassId).NotEmpty();
    }
}