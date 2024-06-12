using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneAddress(Address address) => Create(address);

        public void DeleteOneAddress(Address address) => Delete(address);

        public async Task<IEnumerable<Address>> GetAllAddressesAsync(AddressParameters addressParameters, bool trackChanges)
        {
            return await _context
                       .Addresses
                       .Include(c => c.Country)
                       .Include(p => p.Province)
                       .Include(d => d.District)
                       .Include(n => n.Neighbourhood)
                       //.Include(cs=>cs.Customer)
                       .Search(addressParameters.SearchTerm)
                       .Sort(addressParameters.OrderBy).ToListAsync();
        }
        public async Task<Address> GetOneAddressByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(a => a.Id.Equals(id), trackChanges)
                .Include(ca => ca.CustomerAddresses)
                .Include(a => a.Country)
                .Include(a => a.Province)
                .Include(a => a.District)
                .Include(a => a.Neighbourhood)
                .SingleOrDefaultAsync();

        public async Task<CustomerAddress> GetOneAddressWithCustomerIdAsync(int customerId, int addressId, bool trackChanges)
        {
            return await _context.CustomerAddress
                .Include(x => x.Address)
                .ThenInclude(address => address.Country)
                .Include(x => x.Address.Province)
                .Include(x => x.Address.District)
                .Include(x => x.Address.Neighbourhood)
                .Include(x => x.Customer)
                .SingleOrDefaultAsync(x => x.CustomerId == customerId && x.AddressId == addressId);
        }

        public async Task<IEnumerable<CustomerAddress>> GetOneBranchIdWithAddress(int branchId, bool trackChanges)
        {
            return await _context.CustomerAddress
               .Include(x => x.Address)
               .ThenInclude(address => address.Country)
               .Include(x => x.Address.Province)
               .Include(x => x.Address.District)
               .Include(x => x.Address.Neighbourhood)
               .Include(x => x.Branch)
               .Where(x => x.BranchId == branchId)
               .ToListAsync();
        }

        public async Task<IEnumerable<CustomerAddress>> GetOneCustomerIdWithAddress(int customerId, bool trackChanges)
        {
            return await _context.CustomerAddress
                .Include(x => x.Address)
                .ThenInclude(address => address.Country)
                .Include(x => x.Address.Province)
                .Include(x => x.Address.District)
                .Include(x => x.Address.Neighbourhood)
                .Include(x => x.Customer)
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomerAddress>> GetOneCustomerMobilIdWithAddress(int customerMobilId, bool trackChanges)
        {
            return await _context.CustomerAddress
                .Include(x => x.Address)
                .ThenInclude(address => address.Country)
                .Include(x => x.Address.Province)
                .Include(x => x.Address.District)
                .Include(x => x.Address.Neighbourhood)
                .Include(x => x.CustomerMobil)
                .Where(x => x.CustomerMobilId == customerMobilId)
                .ToListAsync();
        }

        public void UpdateOneAddress(Address address) => Update(address);
    }
}
