using Entities.Models;
using System.Linq.Dynamic.Core;

namespace Repositories.EFCore.Extensions
{
    public static class BranchRepositoryExtensions
    {
        public static IQueryable<Branch> Search(this IQueryable<Branch> branches,
          string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return branches;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return branches
                .Where(a => a.BranchName
                .Contains(lowerCaseTerm));
        }

        public static IQueryable<Branch> Sort(this IQueryable<Branch> branches,
            string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return branches.OrderBy(a => a.Id);

            var orderQuery = OrderQueryBuilder
                .CreateOrderQuery<Branch>(orderByQueryString);

            if (orderQuery is null)
                return branches.OrderBy(a => a.Id);

            return branches.OrderBy(orderQuery);
        }
    }
}
