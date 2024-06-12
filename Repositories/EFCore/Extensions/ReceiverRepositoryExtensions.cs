using Entities.Models;
using System.Linq.Dynamic.Core;

namespace Repositories.EFCore.Extensions
{
    public static class ReceiverRepositoryExtensions
    {
        public static IQueryable<Receiver> Search(this IQueryable<Receiver> receivers,
          string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return receivers;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return receivers
                .Where(a => a.NameSurname
                .Contains(lowerCaseTerm));
        }

        public static IQueryable<Receiver> Sort(this IQueryable<Receiver> receivers,
            string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return receivers.OrderBy(a => a.Id);

            var orderQuery = OrderQueryBuilder
                .CreateOrderQuery<Receiver>(orderByQueryString);

            if (orderQuery is null)
                return receivers.OrderBy(a => a.Id);

            return receivers.OrderBy(orderQuery);
        }
    }
}
