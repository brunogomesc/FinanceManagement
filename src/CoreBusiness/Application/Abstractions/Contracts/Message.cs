﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Contracts
{
    public abstract record Message : ICommand
    {

        public DateTimeOffset Timestamp { get; private set; } = DateTimeOffset.Now;

    }
}
