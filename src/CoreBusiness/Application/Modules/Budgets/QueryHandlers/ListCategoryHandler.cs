using Application.Abstractions.Handlers;
using Application.Abstractions.Ports.Repositories;
using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Modules.Budgets.QueryHandlers
{
    public class ListCategoryHandler : QueryHandler<Query.ListCategoryQuery, List<ViewModel.CategoryViewModel>>
    {

        private readonly IFinanceManagementRepository _repository;

        public ListCategoryHandler(IFinanceManagementRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public override async Task<List<ViewModel.CategoryViewModel>> Handle(Query.ListCategoryQuery query, CancellationToken cancellationToken)
        {
            var categories = await _repository.ListAsync<ViewModel.CategoryViewModel>(prop => prop.AccountId == query.AccountId, cancellationToken);
            return categories;
        }
    }
}
