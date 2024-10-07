using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class UserInventoryEquippedItem : Entity<Guid>
{
    public Guid UserId { get; set; }
    public Guid UserHeroId { get; set; }
    public Guid RightHand { get; set; }
    public Guid LeftHand { get; set; }
    public bool IsWeaponOneHanded { get; set; }
    public Guid ArmorId { get; set; }
    public Guid ConsumableSlot { get; set; }
    public decimal Amount { get; set; }
}
