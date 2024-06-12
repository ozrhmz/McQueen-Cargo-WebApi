using Entities.Exceptions.AlreadyExcepitons;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;


namespace Repositories.EFCore
{
    internal class CustomerMobilRepository : RepositoryBase<CustomerMobil>, ICustomerMobilRepository
    {
        public CustomerMobilRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCustomer(CustomerMobil customerMobil)
        {
            if (_context.CustomerMobil.Any(c => c.TcNo == customerMobil.TcNo))
                throw new CustomerAlreadyExistException(customerMobil.TcNo);
            if (_context.CustomerMobil.Any(c => c.Email == customerMobil.Email))
                throw new CustomerAlreadyExistException(customerMobil.Email);
            if (_context.CustomerMobil.Any(c => c.NumberPhone == customerMobil.NumberPhone))
                throw new CustomerAlreadyExistException(customerMobil.NumberPhone);
            Create(customerMobil);
        }

        public void DeleteOneCustomer(CustomerMobil customerMobil) => Delete(customerMobil);

        public async Task<IEnumerable<CustomerMobil>> GetAllCustomersAsync(CustomerMobilParameters customerMobilParameters, bool trackChanges) =>
            await FindAll(trackChanges)
            .Search(customerMobilParameters.SearchTerm)
            .Sort(customerMobilParameters.OrderBy)
            .ToListAsync();

        public async Task<CustomerMobil> GetOneCustomerByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<CustomerMobil> GetOneCustomerByTCNoAsync(string TCNo, bool trackChanges) =>
             await FindByCondition(c => c.TcNo.Equals(TCNo), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<CustomerMobil> LoginGetOneCustomerByTCNoAsync(string TCNo, bool trackChanges)
        {
            return await FindByCondition(c => c.TcNo.Equals(TCNo), trackChanges)
                .SingleOrDefaultAsync();
        }

        public async Task<CustomerMobil> LoginGetOneCustomerByNumberPhoneAsync(string telNo, bool trackChanges)
        {
            return await FindByCondition(c => c.NumberPhone.Equals(telNo), trackChanges)
               .SingleOrDefaultAsync();
        }

        public void UpdateOneCustomer(CustomerMobil customerMobil) => Update(customerMobil);

        public async Task<CustomerMobil> LoginGetOneCustomerByMailAsync(string mail, bool trackChanges)
        {
            return await FindByCondition(c => c.Email.Equals(mail), trackChanges)
                .SingleOrDefaultAsync();
        }

        public async Task<CustomerMobil> ForgotPasswordCustomerMobil(string mail, bool trackChanges)
        {
            return await FindByCondition(c => c.Email.Equals(mail), trackChanges)
                .SingleOrDefaultAsync();
        }
    }
}
