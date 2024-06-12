using Entities.DTO_s;
using Entities.Models;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<ExpandoObject>> GetAllCustomersAsync(CustomerParameters customerParameters, bool trackChanges);
        Task<CustomerDto> GetOneCustomerByIdAsync(int id, bool trackChanges);
        Task<CustomerDto> GetOneCustomerByTCNoAsync(string TCNo, bool trackChanges);
        Task<CustomerDto> CreateOneCustomerAsync(CustomerDtoForInsertion customerDto);
        Task UpdateOneCustomerAsync(int id, CustomerDtoForUpdate customerDto, bool trackChanges);
        Task DeleteOneCustomerAsync(int id, bool trackChanges);
        Task<(CustomerDtoForUpdate customerDtoForUpdate, Customer customer)> GetOneCustomerForPatchAsync(int id, bool trackChanges);
        Task SaveChangesForPatchAsync(CustomerDtoForUpdate customerDtoForUpdate, Customer customer);
    }
}
