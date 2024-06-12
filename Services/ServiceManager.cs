using AutoMapper;
using Entities.DTO_s;
using Entities.DTO_s.Branch;
using Entities.DTO_s.CustomerMobil;
using Entities.DTO_s.Receiver;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;


namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICustomerService> _customerService;
        private readonly Lazy<IAddressService> _addressService;
        private readonly Lazy<ICustomerMobilService> _customerMobilService;
        private readonly Lazy<IBranchService> _branchService;
        private readonly Lazy<IReceiverService> _receiverService;
        private readonly Lazy<ICountryService> _countryService;
        private readonly Lazy<IProvinceService> _provinceService;
        private readonly Lazy<IDistrictService> _districtService;
        private readonly Lazy<INeighbourhoodService> _neighbourhoodService;
        private readonly Lazy<ICargoStatusService> _cargoStatusService;
        private readonly Lazy<ICargoTransportationConditionsService> _cargoTransportationConditionsService;
        private readonly Lazy<IPaymentTypeService> _paymentTypeService;
        private readonly Lazy<ICargoTypeService> _cargoTypeService;
        private readonly Lazy<ICallCourierService> _callCourierService;
        private readonly Lazy<ICargoParcelTypeService> _cargoParcelTypeService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IEmployeeTypeService> _employeeTypeService;
        private readonly Lazy<ICargoService> _cargoService;
        private readonly Lazy<ICargoMovementService> _cargoMovementService;
        private readonly Lazy<IAuthenticationService> _authencationService;


        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService logger,
            IMapper mapper,
            IDataShaper<CustomerDto> shaperCustomer,
            IDataShaper<AddressDto> shaperAddress,
            IDataShaper<CustomerMobilDto> shaperCustomerMobil,
            IDataShaper<BranchDto> shaperBranch,
            IDataShaper<ReceiverDto> shaperReceiver,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _customerService = new Lazy<ICustomerService>(() => new CustomerManager(repositoryManager, logger, mapper, shaperCustomer));
            _addressService = new Lazy<IAddressService>(() => new AddressManager(repositoryManager, mapper, logger, shaperAddress));
            _customerMobilService = new Lazy<ICustomerMobilService>(() => new CustomerMobilManager(repositoryManager, logger, mapper, shaperCustomerMobil));
            _branchService = new Lazy<IBranchService>(() => new BranchManager(repositoryManager, mapper, logger, shaperBranch));
            _receiverService = new Lazy<IReceiverService>(() => new ReceiverManager(repositoryManager, mapper, logger, shaperReceiver));
            _countryService = new Lazy<ICountryService>(() => new CountryManager(mapper, repositoryManager));
            _provinceService = new Lazy<IProvinceService>(() => new ProvinceManager(mapper, repositoryManager));
            _districtService = new Lazy<IDistrictService>(() => new DistrictManager(mapper, repositoryManager));
            _neighbourhoodService = new Lazy<INeighbourhoodService>(() => new NeighbourhoodManager(mapper, repositoryManager));
            _cargoStatusService = new Lazy<ICargoStatusService>(() => new CargoStatusManager(repositoryManager, mapper));
            _cargoTransportationConditionsService = new Lazy<ICargoTransportationConditionsService>(() => new CargoTransportationConditionsManager(repositoryManager, mapper));
            _paymentTypeService = new Lazy<IPaymentTypeService>(() => new PaymentTypeManager(repositoryManager, mapper));
            _cargoTypeService = new Lazy<ICargoTypeService>(() => new CargoTypeManager(repositoryManager, mapper));
            _callCourierService = new Lazy<ICallCourierService>(() => new CallCourierManager(repositoryManager, mapper, logger));
            _cargoParcelTypeService = new Lazy<ICargoParcelTypeService>(() => new CargoParcelTypeManager(mapper, repositoryManager));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeManager(repositoryManager, mapper, logger));
            _employeeTypeService = new Lazy<IEmployeeTypeService>(() => new EmployeeTypeManager(repositoryManager, mapper));
            _cargoService = new Lazy<ICargoService>(() => new CargoManager(repositoryManager, mapper, logger));
            _cargoMovementService = new Lazy<ICargoMovementService>(() => new CargoMovementManager(repositoryManager, mapper, logger));
            _authencationService = new Lazy<IAuthenticationService>(() => new AuthenticationManager(logger, mapper, userManager, configuration));
        }

        public ICustomerService CustomerService => _customerService.Value;
        public IAddressService AddressService => _addressService.Value;
        public ICustomerMobilService CustomerMobilService => _customerMobilService.Value;
        public IBranchService BranchService => _branchService.Value;
        public IReceiverService ReceiverService => _receiverService.Value;
        public ICountryService CountryService => _countryService.Value;
        public IProvinceService ProvinceService => _provinceService.Value;
        public IDistrictService DistrictService => _districtService.Value;
        public INeighbourhoodService NeighbourhoodService => _neighbourhoodService.Value;
        public ICargoStatusService CargoStatusService => _cargoStatusService.Value;
        public ICargoTransportationConditionsService CargoTransportationConditions => _cargoTransportationConditionsService.Value;
        public IPaymentTypeService PaymentTypeService => _paymentTypeService.Value;
        public ICargoTypeService CargoTypeService => _cargoTypeService.Value;
        public ICallCourierService CallCourierService => _callCourierService.Value;
        public ICargoParcelTypeService CargoParcelTypeService => _cargoParcelTypeService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;
        public IEmployeeTypeService EmployeeTypeService => _employeeTypeService.Value;
        public ICargoService CargoService => _cargoService.Value;
        public ICargoMovementService CargoMovementService => _cargoMovementService.Value;
        public IAuthenticationService AuthenticationService => _authencationService.Value;
    }
}
