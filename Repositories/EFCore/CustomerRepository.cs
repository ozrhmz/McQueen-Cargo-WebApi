using Entities.Exceptions.AlreadyExcepitons;
using Entities.Exceptions.NotFoundExceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCustomer(Customer customer)
        {
            if (_context.Customers.Any(c => c.TCNo == customer.TCNo))
                throw new CustomerAlreadyExistException(customer.TCNo);
            Create(customer);
        }

        public void DeleteOneCustomer(Customer customer) => Delete(customer);

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync(CustomerParameters customerParameters, bool trackChanges) =>
             await FindAll(trackChanges)
            .Search(customerParameters.SearchTerm)
            .Sort(customerParameters.OrderBy)
            .ToListAsync();

        public async Task<Customer> GetOneCustomerByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<Customer> GetOneCustomerByTCNoAsync(string TCNo, bool trackChanges)
        {
            var Customer = await _context.Customers.Where(x => x.TCNo.Equals(TCNo))
                .FirstOrDefaultAsync();
            if (Customer is null)
                throw new CustomerNotFoundException(TCNo);

            return Customer;
        }

        public void UpdateOneCustomer(Customer customer) => Update(customer);
    }
}
