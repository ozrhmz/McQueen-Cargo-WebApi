using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    public interface ICustomerMobilRepository : IRepositoryBase<CustomerMobil>
    {
        Task<IEnumerable<CustomerMobil>> GetAllCustomersAsync(CustomerMobilParameters customerMobilParameters, bool trackChanges);
        Task<CustomerMobil> GetOneCustomerByIdAsync(int id, bool trackChanges);
        Task<CustomerMobil> GetOneCustomerByTCNoAsync(string TCNo, bool trackChanges);
        void CreateOneCustomer(CustomerMobil customerMobil);
        void UpdateOneCustomer(CustomerMobil customerMobil);
        void DeleteOneCustomer(CustomerMobil customerMobil);
        Task<CustomerMobil> LoginGetOneCustomerByTCNoAsync(string TCNo, bool trackChanges);
        Task<CustomerMobil> LoginGetOneCustomerByNumberPhoneAsync(string telNo, bool trackChanges);
        Task<CustomerMobil> LoginGetOneCustomerByMailAsync(string mail, bool trackChanges);
        Task<CustomerMobil> ForgotPasswordCustomerMobil(string mail, bool trackChanges);
    }
}
