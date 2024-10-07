using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class UserWallet : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid DefinitionWalletTypeId { get; set; }
    public string? WalletAddress { get; set; }
}
