using Entities.DTO_s.CustomerMobil;
using Entities.Models;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts
{
    public interface ICustomerMobilService
    {
        Task<IEnumerable<ExpandoObject>> GetAllCustomersAsync(CustomerMobilParameters customerMobilParameters, bool trackChanges);
        Task<CustomerMobilDto> GetOneCustomerByIdAsync(int id, bool trackChanges);
        Task<CustomerMobilDto> GetOneCustomerByTCNoAsync(string TCNo, bool trackChanges);
        Task<CustomerMobilDto> CreateOneCustomerAsync(CustomerMobilDtoForInsertion customerMobilDto);
        Task UpdateOneCustomerAsync(int id, CustomerMobilDtoForUpdate customerMobilDto, bool trackChanges);
        Task DeleteOneCustomerAsync(int id, bool trackChanges);
        Task<(CustomerMobilDtoForUpdate customerMobilDtoForUpdate, CustomerMobil customerMobil)> GetOneCustomerForPatchAsync(int id, bool trackChanges);
        Task SaveChangesForPatchAsync(CustomerMobilDtoForUpdate customerDtoForUpdate, CustomerMobil customerMobil);
        Task<CustomerMobilDto> UserLoginAsync(string userName, string password);
        Task<CustomerMobilDto> UserUpdatePasswordAsync(int CustomerMobilId, string oldPassword, string newPassword);
        Task<CustomerMobilDto> ForgotPasswordCustomerMobil(string Email, string newPassword);
    }
}
