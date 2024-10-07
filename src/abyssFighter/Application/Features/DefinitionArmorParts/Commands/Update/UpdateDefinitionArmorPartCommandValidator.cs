using FluentValidation;

namespace Application.Features.DefinitionArmorParts.Commands.Update;

public class UpdateDefinitionArmorPartCommandValidator : AbstractValidator<UpdateDefinitionArmorPartCommand>
{
    public UpdateDefinitionArmorPartCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}