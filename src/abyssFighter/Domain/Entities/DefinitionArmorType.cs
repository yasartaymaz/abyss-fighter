﻿using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class DefinitionArmorType : Entity<Guid>
{
    public string? Value { get; set; }
    public Guid HeroClassId { get; set; }
}
