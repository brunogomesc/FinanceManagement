using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Accounts.ValuesObjects.Address
{
    public record Address(string Street, string State, string ZipCode, string Country, int? Number, string? Complement)
    {
    }
}
