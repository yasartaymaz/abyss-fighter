using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class DefinitionItem : Entity<Guid>
{
	public Guid DefinitionItemTypeId { get; set; }
	public Guid ItemId { get; set; }
	public bool IsStackable { get; set; }
	public bool IsWeapon { get; set; }
	public bool IsArmor { get; set; }
}
