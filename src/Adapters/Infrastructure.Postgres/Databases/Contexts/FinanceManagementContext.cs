using Application.Contracts;
using Domain.Modules.Accounts.Aggregates;
using Domain.Modules.Accounts.Entities.Profiles;
using Domain.Modules.Accounts.ValuesObjects.Address;
using Domain.Modules.Budgets.Aggregates;
using Domain.Modules.Budgets.ValuesObjects.Categories;
using Domain.Modules.Budgets.ValuesObjects.Transactions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Postgres.Databases.Contexts
{
    public class FinanceManagementContext : DbContext
    {

        #region Account

        public DbSet<Account> Account { get; set; }

        public DbSet<Profile> Profile { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        #endregion

        #region Budget

        public DbSet<Budget> Budget { get; set; }

        public DbSet<Category> Categories { get; set; }

        #endregion

        #region Views

        public DbSet<ViewModel.BalanceViewModel> BalanceView { get; set; }

        public DbSet<ViewModel.CategoryViewModel> CategoryView { get; set; }

        public DbSet<ViewModel.TransactionViewModel> TransactionView { get; set; }

        #endregion

        public FinanceManagementContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Entity<ViewModel.BalanceViewModel>().HasNoKey().ToView(nameof(ViewModel.BalanceViewModel));

            modelBuilder.Entity<ViewModel.CategoryViewModel>().HasNoKey().ToView(nameof(ViewModel.CategoryViewModel));

            modelBuilder.Entity<ViewModel.TransactionViewModel>().HasNoKey().ToView(nameof(ViewModel.TransactionViewModel));

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
            => configurationBuilder
                .Properties<string>()
                .AreUnicode(false)
                .HaveMaxLength(1024);

    }
}
