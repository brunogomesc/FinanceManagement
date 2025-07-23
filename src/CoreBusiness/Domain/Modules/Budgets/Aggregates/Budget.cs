using Domain.Abstractions.Aggregates;
using Domain.Modules.Budgets.ValuesObjects.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modules.Budgets.Aggregates
{
    public class Budget : AggregateRoot
    {

        private readonly List<Category> _categories = [];

        public Guid OwnerId { get; private set; }

        public DateOnly ReferencePeriod { get; private set; }

        public decimal TotalValue { get; private set; }

        //public Category Category { get; private set; }

        public IEnumerable<Category> Categories => _categories.AsReadOnly();

        public void Register(Guid ownerId, DateOnly referencePeriod, decimal totalValue)
        {
            if (ownerId == Guid.Empty)
                throw new ArgumentException("Owner ID cannot be empty.", nameof(ownerId));

            if (totalValue <= 0)
                throw new ArgumentOutOfRangeException(nameof(totalValue), "Total value must be greater than zero.");

            OwnerId = ownerId;
            ReferencePeriod = referencePeriod;
            TotalValue = totalValue;
        }

        public void AddCategory(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category), "Category cannot be null.");

            if (_categories.Any(c => c.Name == category.Name))
                throw new InvalidOperationException($"Category with name '{category.Name}' already exists.");

            _categories.Add(category);
        }

        public void UpdateTotalValue(decimal newTotalValue)
        {
            if (newTotalValue <= 0)
                throw new ArgumentOutOfRangeException(nameof(newTotalValue), "Total value must be greater than zero.");

            TotalValue = newTotalValue;
        }

        public void RegisterTransaction(string category, DateTime createdAt, string description, decimal value)
        {
            _categories
                .Single(c => c.Name.Equals(category, StringComparison.OrdinalIgnoreCase))
                .RegisterTransaction(createdAt, description, value);
        }

    }
}
