using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class UserPet : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid DefinitionPetId { get; set; }
	public decimal HealthPoints { get; set; }
	public decimal AttackPoints { get; set; }
	public decimal DefencePoints { get; set; }
}
