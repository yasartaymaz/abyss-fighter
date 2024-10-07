using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class DefinitionPet : Entity<Guid>
{
	public Guid DefinitionPetTypeId { get; set; }
	public string? Name { get; set; }
	public decimal AttackPoints { get; set; }
	public decimal DefencePoints { get; set; }
    public decimal HealthPoints { get; set; }
}
