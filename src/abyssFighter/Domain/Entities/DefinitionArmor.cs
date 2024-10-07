using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class DefinitionArmor : Entity<Guid>
{
    public Guid DefinitionArmorTypeId { get; set; }
    public Guid DefinitionArmorPartId { get; set; }
    public string? Name { get; set; }
    public decimal DefencePoints { get; set; }
}
