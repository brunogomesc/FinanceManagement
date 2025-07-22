using Domain.Modules.Accounts.Aggregates;
using Domain.Modules.Accounts.Entities.Profiles;
using Domain.Modules.Accounts.ValuesObjects.Address;
using Domain.Modules.Budgets.ValuesObjects.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Postgres.Databases.Configurations.Accounts
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {

        public void Configure(EntityTypeBuilder<Account> builder)
        {

            builder.ToTable(nameof(Account));

            builder.HasKey(account => account.Id);

            builder.HasOne(accout => accout.Profile)
                .WithOne(profile => profile.Account)
                .HasForeignKey<Profile>(profile => profile.AccountId)
                .IsRequired();

            builder.OwnsOne(
                account => account.Address,
                addressNavigationBuilder =>
                {
                    addressNavigationBuilder.ToTable(nameof(Address));
                    addressNavigationBuilder.Property<int>("Id").IsRequired();
                    addressNavigationBuilder.HasKey("Id");
                }
            );
        }
    }
}
