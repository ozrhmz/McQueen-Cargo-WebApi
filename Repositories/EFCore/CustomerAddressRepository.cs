using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CustomerAddressRepository : RepositoryBase<CustomerAddress>, ICustomerAdressRepository
    {
        public CustomerAddressRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneAddress(int customerId, int addressId)
        {
            var customerAddress = new CustomerAddress
            {
                CustomerId = customerId,
                AddressId = addressId
            };

            _context.CustomerAddress.Add(customerAddress);
            _context.SaveChanges();
        }

        public void CreateOneAdressBranch(int branchId, int adressId)
        {
            var branchAddress = new CustomerAddress
            {
                BranchId = branchId,
                AddressId = adressId
            };

            _context.CustomerAddress.Add(branchAddress);
            _context.SaveChanges();
        }

        public void CreateOneAdressMobil(int customerMobilId, int adressId)
        {
            var customerAddress = new CustomerAddress
            {
                CustomerMobilId = customerMobilId,
                AddressId = adressId
            };
            _context.CustomerAddress.Add(customerAddress);
            _context.SaveChanges();
        }

        public void DeleteAdress(IEnumerable<CustomerAddress> customerAdress)
        {
            _context.CustomerAddress.RemoveRange(customerAdress);
            _context.SaveChanges();
        }
    }
}
