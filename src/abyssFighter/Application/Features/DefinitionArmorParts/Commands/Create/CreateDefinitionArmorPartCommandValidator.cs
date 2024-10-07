using FluentValidation;

namespace Application.Features.DefinitionArmorParts.Commands.Create;

public class CreateDefinitionArmorPartCommandValidator : AbstractValidator<CreateDefinitionArmorPartCommand>
{
    public CreateDefinitionArmorPartCommandValidator()
    {
    }
}