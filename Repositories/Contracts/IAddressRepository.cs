using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts
{
    public interface IAddressRepository : IRepositoryBase<Address>
    {
        Task<IEnumerable<Address>> GetAllAddressesAsync(AddressParameters addressParameters, bool trackChanges); //Tüm addresler
        Task<Address> GetOneAddressByIdAsync(int id, bool trackChanges); //AdresId
        void CreateOneAddress(Address address); //Create
        void UpdateOneAddress(Address address); //Update
        void DeleteOneAddress(Address address); //Delete
        Task<CustomerAddress> GetOneAddressWithCustomerIdAsync(int customerId, int addressId, bool trackChanges); //CustmerId ve AddressId
        Task<IEnumerable<CustomerAddress>> GetOneCustomerIdWithAddress(int customerId, bool trackChanges); //CustomerId'ye göre adresler
        Task<IEnumerable<CustomerAddress>> GetOneCustomerMobilIdWithAddress(int customerMobilId, bool trackChanges); //CustomerId'ye göre adresler
        Task<IEnumerable<CustomerAddress>> GetOneBranchIdWithAddress(int branchId, bool trackChanges); //BranchId'ye göre adresler
    }
}
