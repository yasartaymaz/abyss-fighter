using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class DefinitionWeapon : Entity<Guid>
{
	public Guid DefinitionWeaponTypeId { get; set; }
	public string? Name { get; set; }
	public bool IsOneHanded { get; set; }
	public decimal AttackPoints { get; set; }
	public decimal AttackSpeedMultiplier { get; set; }
}
