using Entities.Models;
using System.Linq.Dynamic.Core;

namespace Repositories.EFCore.Extensions
{
    public static class CustomerMobilRepositoryExtensions
    {
        public static IQueryable<CustomerMobil> Search(this IQueryable<CustomerMobil> customersMobil,
            string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return customersMobil;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return customersMobil
                .Where(b => b.TcNo
                .ToLower()
                .Contains(searchTerm));
        }

        public static IQueryable<CustomerMobil> Sort(this IQueryable<CustomerMobil> customersMobil,
            string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return customersMobil.OrderBy(b => b.Id);

            var orderQuery = OrderQueryBuilder
                .CreateOrderQuery<Customer>(orderByQueryString);

            if (orderQuery is null)
                return customersMobil.OrderBy(c => c.Id);

            return customersMobil.OrderBy(orderQuery);
        }
    }
}