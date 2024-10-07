using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class UserHero : Entity<Guid>
{
	public Guid UserId { get; set; }
	public string? Name { get; set; }
	public Guid DefinitionHeroClassId { get; set; }
}
