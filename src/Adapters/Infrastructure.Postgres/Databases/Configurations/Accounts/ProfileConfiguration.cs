using Domain.Modules.Accounts.Aggregates;
using Domain.Modules.Accounts.Entities.Profiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Postgres.Databases.Configurations.Accounts
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable(nameof(Profile));

            builder.HasKey(profile => profile.Id);

            builder
                .HasOne(profile => profile.Account)
                .WithOne(account => account.Profile)
                .IsRequired();
        }
    }
}
