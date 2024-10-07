using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class UserPetDetail : Entity<Guid>
{
    public Guid UserPetId { get; set; }
    public decimal AttackPoints { get; set; }
    public decimal DefencePoints { get; set; }
}
