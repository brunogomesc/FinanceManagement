﻿using Domain.Abstractions.Entities;
using Domain.Modules.Accounts.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Accounts.Entities.Profiles
{
    public class Profile : Entity
    {

        public Profile(string firstName, string lastName, string email)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        #region Navigation References

        protected Profile() {}

        public Guid AccountId { get; }

        public Account  Account { get; }

        #endregion

    }
}
