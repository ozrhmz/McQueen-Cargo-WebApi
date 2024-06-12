using Entities.Models;
using System.Linq.Dynamic.Core;

namespace Repositories.EFCore.Extensions
{
    public static class AddressRepositoryExtensions
    {
        public static IQueryable<Address> Search(this IQueryable<Address> addresses,
            string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return addresses;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return addresses
                .Where(a => a.District.DistrictName
                .Contains(lowerCaseTerm));
        }

        public static IQueryable<Address> Sort(this IQueryable<Address> addresses,
            string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return addresses.OrderBy(a => a.Id);

            var orderQuery = OrderQueryBuilder
                .CreateOrderQuery<Address>(orderByQueryString);

            if (orderQuery is null)
                return addresses.OrderBy(a => a.Id);

            return addresses.OrderBy(orderQuery);
        }
    }
}
