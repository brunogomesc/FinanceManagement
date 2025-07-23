using Application.Contracts;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AlterViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                CREATE OR REPLACE VIEW {nameof(ViewModel.BalanceViewModel)} AS
                    SELECT 
                        b.""OwnerId"" AS AccountId,
                        SUM(b.""TotalValue"") AS TotalSpent,
                        (SUM(b.""TotalValue"") - COALESCE(SUM(t.""Value""), 0)) AS Balance
                    FROM 
                        public.""Budget"" b
                    LEFT JOIN
                        public.""Category"" c on c.""BudgetId"" = b.""Id""
                    JOIN
                        public.""Transaction"" t ON c.""Id"" = t.""CategoryId""
                    GROUP BY
                        b.""OwnerId"";
            ");

            migrationBuilder.Sql($@"
                CREATE OR REPLACE VIEW {nameof(ViewModel.CategoryViewModel)} AS
                    SELECT 
                    	c.""BudgetId"" AS AccountId,
                    	c.""Name"" AS CategoryName,
                    	c.""Limit"" AS CategoryLimit
                    FROM 
                    	public.""Category"" c;
            ");

            migrationBuilder.Sql($@"
                CREATE OR REPLACE VIEW {nameof(ViewModel.TransactionViewModel)} AS
                    select  
                    	b.""OwnerId"" as AccountId,
                    	c.""Name"" as CategoryName,
                    	t.""CreatedAt"",
                    	t.""Description"",
                    	t.""Value""
                    from 
                    	public.""Transaction"" t
                    join
                    	public.""Category"" c on t.""CategoryId"" = c.""Id""
                    join
                    	public.""Budget"" b on c.""BudgetId"" = b.""Id"";
            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP VIEW IF EXISTS ""{nameof(ViewModel.BalanceViewModel)}"";");
            migrationBuilder.Sql($@"DROP VIEW IF EXISTS ""{nameof(ViewModel.CategoryViewModel)}"";");
            migrationBuilder.Sql($@"DROP VIEW IF EXISTS ""{nameof(ViewModel.TransactionViewModel)}"";");
        }
    }
}
