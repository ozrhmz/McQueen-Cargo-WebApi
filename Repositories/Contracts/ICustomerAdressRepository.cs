using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICustomerAdressRepository : IRepositoryBase<CustomerAddress>
    {
        void CreateOneAddress(int customerId, int addressId);
        void CreateOneAdressMobil(int customerMobilId, int adressId);
        void CreateOneAdressBranch(int branchId, int adressId);
        void DeleteAdress(IEnumerable<CustomerAddress> customerAdress);
    }
}
