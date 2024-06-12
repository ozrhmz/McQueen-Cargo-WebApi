using AutoMapper;
using Entities.DTO_s;
using Entities.Exceptions.NotFoundExceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;

namespace Services
{
    public class CustomerManager : ICustomerService
    {

        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<CustomerDto> _shaper;

        public CustomerManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IDataShaper<CustomerDto> shaper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _shaper = shaper;
        }

        public async Task<CustomerDto> CreateOneCustomerAsync(CustomerDtoForInsertion customerDto)
        {
            var entity = _mapper.Map<Customer>(customerDto);
            _manager.Customer.CreateOneCustomer(entity);
            await _manager.SaveAsync();
            return _mapper.Map<CustomerDto>(entity);
        }

        public async Task DeleteOneCustomerAsync(int id, bool trackChanges)
        {
            var entity = await GetOneCustomerAndCheckExist(id, trackChanges);
            _manager.Customer.DeleteOneCustomer(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<ExpandoObject>> GetAllCustomersAsync(CustomerParameters customerParameters, bool trackChanges)
        {
            var customers = await _manager.Customer.GetAllCustomersAsync(customerParameters, trackChanges);
            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            var shapedData = _shaper.ShapeData(customersDto, customerParameters.Fields);
            return shapedData;
        }

        public async Task<CustomerDto> GetOneCustomerByIdAsync(int id, bool trackChanges)
        {
            var customer = await GetOneCustomerAndCheckExist(id, trackChanges);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> GetOneCustomerByTCNoAsync(string TCNo, bool trackChanges)
        {
            var entity = await _manager.Customer.GetOneCustomerByTCNoAsync(TCNo, trackChanges);
            var customer = _mapper.Map<CustomerDto>(entity);
            return customer;
        }

        public async Task<(CustomerDtoForUpdate customerDtoForUpdate, Customer customer)> GetOneCustomerForPatchAsync(int id, bool trackChanges)
        {
            var customer = await GetOneCustomerAndCheckExist(id, trackChanges);
            var customerDtoForUpdate = _mapper.Map<CustomerDtoForUpdate>(customer);
            return (customerDtoForUpdate, customer);
        }

        public async Task SaveChangesForPatchAsync(CustomerDtoForUpdate customerDtoForUpdate, Customer customer)
        {
            var a = _mapper.Map(customerDtoForUpdate, customer);
            _manager.Customer.Update(a);
            await _manager.SaveAsync();
        }

        public async Task UpdateOneCustomerAsync(int id, CustomerDtoForUpdate customerDto, bool trackChanges)
        {
            var entity = await GetOneCustomerAndCheckExist(id, trackChanges);
            entity = _mapper.Map<Customer>(customerDto);
            _manager.Customer.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Customer> GetOneCustomerAndCheckExist(int id, bool trackChanges)
        {
            var entity = await _manager.Customer.GetOneCustomerByIdAsync(id, trackChanges);
            if (entity is null)
                throw new CustomerNotFoundException(id);

            return entity;
        }
    }
}
