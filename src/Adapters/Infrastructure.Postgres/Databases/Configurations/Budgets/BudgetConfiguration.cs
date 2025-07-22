using Domain.Modules.Budgets.Aggregates;
using Domain.Modules.Budgets.ValuesObjects.Categories;
using Domain.Modules.Budgets.ValuesObjects.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Postgres.Databases.Configurations.Budgets
{
    public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
            builder.ToTable(nameof(Budget));

            builder.HasKey(budget => budget.Id);

            builder.OwnsMany(
                budget => budget.Categories,
                budgetNavigationBuilder =>
                {
                    budgetNavigationBuilder.ToTable(nameof(Category));
                    budgetNavigationBuilder.Property<int>("Id").IsRequired();
                    budgetNavigationBuilder.HasKey("Id");

                    budgetNavigationBuilder.OwnsMany(
                        account => account.Transactions,
                        transactionNavigationBuilder =>
                        {
                            transactionNavigationBuilder.ToTable(nameof(Transaction));
                            transactionNavigationBuilder.Property<int>("Id").IsRequired();
                            transactionNavigationBuilder.HasKey("Id");
                        }
                    );
                }
            );

        }
    }
}
