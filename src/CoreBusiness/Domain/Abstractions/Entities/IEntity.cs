﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Entities
{
    public interface IEntity
    {

        Guid Id { get; }

        bool IsDeleted { get; }

    }
}
