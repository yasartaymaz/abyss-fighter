using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class UserInventory : Entity<Guid>
{
	public Guid UserId { get; set; }
	public Guid UserHeroId { get; set; }
	public Guid DefinitionItemId { get; set; }
	public Guid DefinitionItemTypeId { get; set; }
	public decimal Amount { get; set; }
}
