using FluentValidation;

namespace Application.Features.DefinitionItems.Commands.Delete;

public class DeleteDefinitionItemCommandValidator : AbstractValidator<DeleteDefinitionItemCommand>
{
    public DeleteDefinitionItemCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}