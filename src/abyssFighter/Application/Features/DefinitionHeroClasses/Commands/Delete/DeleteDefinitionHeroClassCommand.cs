using Application.Features.DefinitionHeroClasses.Constants;
using Application.Features.DefinitionHeroClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.DefinitionHeroClasses.Commands.Delete;

public class DeleteDefinitionHeroClassCommand : IRequest<DeletedDefinitionHeroClassResponse>
{
    public Guid Id { get; set; }

    public class DeleteDefinitionHeroClassCommandHandler : IRequestHandler<DeleteDefinitionHeroClassCommand, DeletedDefinitionHeroClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDefinitionHeroClassRepository _definitionHeroClassRepository;
        private readonly DefinitionHeroClassBusinessRules _definitionHeroClassBusinessRules;

        public DeleteDefinitionHeroClassCommandHandler(IMapper mapper, IDefinitionHeroClassRepository definitionHeroClassRepository,
                                         DefinitionHeroClassBusinessRules definitionHeroClassBusinessRules)
        {
            _mapper = mapper;
            _definitionHeroClassRepository = definitionHeroClassRepository;
            _definitionHeroClassBusinessRules = definitionHeroClassBusinessRules;
        }

        public async Task<DeletedDefinitionHeroClassResponse> Handle(DeleteDefinitionHeroClassCommand request, CancellationToken cancellationToken)
        {
            DefinitionHeroClass? definitionHeroClass = await _definitionHeroClassRepository.GetAsync(predicate: dhc => dhc.Id == request.Id, cancellationToken: cancellationToken);
            await _definitionHeroClassBusinessRules.DefinitionHeroClassShouldExistWhenSelected(definitionHeroClass);

            await _definitionHeroClassRepository.DeleteAsync(definitionHeroClass!);

            DeletedDefinitionHeroClassResponse response = _mapper.Map<DeletedDefinitionHeroClassResponse>(definitionHeroClass);
            return response;
        }
    }
}