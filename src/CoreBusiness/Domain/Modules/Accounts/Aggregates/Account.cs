using Domain.Abstractions.Aggregates;
using Domain.Modules.Accounts.Entities.Profiles;
using Domain.Modules.Accounts.ValuesObjects.Address;
using Domain.Modules.Budgets.ValuesObjects.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Accounts.Aggregates
{
    public class Account : AggregateRoot
    {

        public Profile Profile { get; set; }

        public Address? Address { get; set; }

        public void Create(string firstName, string lastName, string email)
        {
            Id = Guid.NewGuid();
            Profile = new Profile(firstName, lastName, email);
        }

        public void InformAddress(string street, string city, string state, string zipCode, int? number = null, string? complement = null)
        {
            Address = new Address(street, city, state, zipCode, number, complement);
        }
    }
}
