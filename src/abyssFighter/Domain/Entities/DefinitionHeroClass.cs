using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class DefinitionHeroClass : Entity<Guid>
{
    public string? Value { get; set; }
    public decimal HealthPoints { get; set; }
    public decimal AttackPoints { get; set; }
    public decimal DefencePoints { get; set; }
    public decimal AttackSpeedMultiplier { get; set; }
    public Guid? DefaultPetId { get; set; }
}
