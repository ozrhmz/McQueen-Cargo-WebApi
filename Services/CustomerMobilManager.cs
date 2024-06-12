using AutoMapper;
using Entities.DTO_s.CustomerMobil;
using Entities.Exceptions.NotFoundExceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System.Dynamic;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class CustomerMobilManager : ICustomerMobilService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<CustomerMobilDto> _shaper;

        public CustomerMobilManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IDataShaper<CustomerMobilDto> shaper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _shaper = shaper;
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public async Task<CustomerMobilDto> CreateOneCustomerAsync(CustomerMobilDtoForInsertion customerMobilDto)
        {
            var entity = _mapper.Map<CustomerMobil>(customerMobilDto);
            entity.Password = EncryptPassword(customerMobilDto.Password);
            _manager.CustomerMobil.CreateOneCustomer(entity);
            await _manager.SaveAsync();
            return _mapper.Map<CustomerMobilDto>(entity);
        }

        public async Task DeleteOneCustomerAsync(int id, bool trackChanges)
        {
            var entity = await GetOneCustomerAndCheckExist(id, trackChanges);
            _manager.CustomerMobil.DeleteOneCustomer(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<ExpandoObject>> GetAllCustomersAsync(CustomerMobilParameters customerMobilParameters, bool trackChanges)
        {
            var customers = await _manager.CustomerMobil.GetAllCustomersAsync(customerMobilParameters, trackChanges);
            var customersMobilDto = _mapper.Map<IEnumerable<CustomerMobilDto>>(customers);
            var shapedData = _shaper.ShapeData(customersMobilDto, customerMobilParameters.Fields);
            return shapedData;
        }

        public async Task<CustomerMobilDto> GetOneCustomerByIdAsync(int id, bool trackChanges)
        {
            var customerMobil = await GetOneCustomerAndCheckExist(id, trackChanges);
            return _mapper.Map<CustomerMobilDto>(customerMobil);
        }

        public async Task<CustomerMobilDto> GetOneCustomerByTCNoAsync(string TCNo, bool trackChanges)
        {
            var entity = await _manager.CustomerMobil.GetOneCustomerByTCNoAsync(TCNo, trackChanges);
            var customerMobil = _mapper.Map<CustomerMobilDto>(entity);
            return customerMobil;
        }

        public async Task<(CustomerMobilDtoForUpdate customerMobilDtoForUpdate, CustomerMobil customerMobil)> GetOneCustomerForPatchAsync(int id, bool trackChanges)
        {
            var customer = await GetOneCustomerAndCheckExist(id, trackChanges);
            var customerMobilDtoForUpdate = _mapper.Map<CustomerMobilDtoForUpdate>(customer);
            return (customerMobilDtoForUpdate, customer);
        }

        public async Task SaveChangesForPatchAsync(CustomerMobilDtoForUpdate customerDtoForUpdate, CustomerMobil customerMobil)
        {
            _mapper.Map(customerDtoForUpdate, customerMobil);
            await _manager.SaveAsync();
        }

        public async Task UpdateOneCustomerAsync(int id, CustomerMobilDtoForUpdate customerMobilDto, bool trackChanges)
        {
            var entity = await GetOneCustomerAndCheckExist(id, trackChanges);
            entity = _mapper.Map<CustomerMobil>(customerMobilDto);
            _manager.CustomerMobil.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<CustomerMobil> GetOneCustomerAndCheckExist(int id, bool trackChanges)
        {
            var entity = await _manager.CustomerMobil.GetOneCustomerByIdAsync(id, trackChanges);
            if (entity is null)
                throw new CustomerNotFoundException(id);

            return entity;
        }

        public async Task<CustomerMobilDto> UserLoginAsync(string userName, string password)
        {
            var userByTCNo = await _manager.CustomerMobil.LoginGetOneCustomerByTCNoAsync(userName, false);
            var userByNumberPhone = await _manager.CustomerMobil.LoginGetOneCustomerByNumberPhoneAsync(userName, false);
            var userByMail = await _manager.CustomerMobil.LoginGetOneCustomerByMailAsync(userName, false);

            return await ValidateUser(userByTCNo, password) ??
                   await ValidateUser(userByNumberPhone, password) ??
                   await ValidateUser(userByMail, password);
        }

        private async Task<CustomerMobilDto> ValidateUser(CustomerMobil user, string password)
        {
            if (user != null && VerifyPassword(password, user.Password))
            {
                var customerMobil = _mapper.Map<CustomerMobilDto>(user);
                return customerMobil;
            }
            return null;
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] enteredBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
                StringBuilder enteredSB = new StringBuilder();
                for (int i = 0; i < enteredBytes.Length; i++)
                {
                    enteredSB.Append(enteredBytes[i].ToString("x2"));
                }

                return enteredSB.ToString() == storedPassword;
            }
        }

        public async Task<CustomerMobilDto> UserUpdatePasswordAsync(int CustomerMobilId, string oldPassword, string newPassword)
        {
            var customer = await _manager.CustomerMobil.GetOneCustomerByIdAsync(CustomerMobilId, false);
            if (customer == null)
                throw new CustomerNotFoundException(CustomerMobilId);

            if (VerifyPassword(oldPassword, customer.Password))
            {
                newPassword = EncryptPassword(newPassword);
                customer.Password = newPassword;
                _manager.CustomerMobil.Update(customer);
                await _manager.SaveAsync();
                var customerMobil = _mapper.Map<CustomerMobilDto>(customer);
                return customerMobil;
            }
            else
            {
                throw new Exception("Hatalı şifre girişi yapıldı.");
            }
        }

        public async Task<CustomerMobilDto> ForgotPasswordCustomerMobil(string Email, string newPassword)
        {
            var customer = await _manager.CustomerMobil.ForgotPasswordCustomerMobil(Email, false);
            if (customer == null)
                throw new CustomerNotFoundException();

            newPassword = EncryptPassword(newPassword);
            customer.Password = newPassword;
            _manager.CustomerMobil.Update(customer);
            await _manager.SaveAsync();
            var customerMobil = _mapper.Map<CustomerMobilDto>(customer);
            return customerMobil;
        }
    }
}
