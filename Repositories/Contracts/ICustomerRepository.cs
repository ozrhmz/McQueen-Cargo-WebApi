using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync(CustomerParameters customerParameters, bool trackChanges);
        Task<Customer> GetOneCustomerByIdAsync(int id, bool trackChanges);
        Task<Customer> GetOneCustomerByTCNoAsync(string TCNo, bool trackChanges);
        void CreateOneCustomer(Customer customer);
        void UpdateOneCustomer(Customer customer);
        void DeleteOneCustomer(Customer customer);
    }
}
