using Repositories.Contracts;


namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {

        private readonly RepositoryContext _context;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IAddressRepository> _addressRepository;
        private readonly Lazy<ICustomerAdressRepository> _customerAdressRepository;
        private readonly Lazy<ICustomerMobilRepository> _customerMobilRepository;
        private readonly Lazy<IBranchRepository> _branchRepository;
        private readonly Lazy<IReceiverRepository> _receiverRepository;
        private readonly Lazy<ICountryRepository> _countryRepository;
        private readonly Lazy<IProvinceRepository> _provinceRepository;
        private readonly Lazy<IDistrictRepository> _districtRepository;
        private readonly Lazy<INeighbourhoodRepository> _neighbourhoodRepository;
        private readonly Lazy<ICargoStatusRepository> _cargoStatusRepository;
        private readonly Lazy<ICargoTransportationConditionsRepository> _cargoTransportationConditionsRepository;
        private readonly Lazy<IPaymentTypeRepository> _paymentTypeRepository;
        private readonly Lazy<ICargoTypeRepository> _cargoTypeRepository;
        private readonly Lazy<ICallCourierRepository> _callCourierRepository;
        private readonly Lazy<ICargoParcelType> _cargoParcelType;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IEmployeeTypeRepository> _employeeTypeRepository;
        private readonly Lazy<ICargoRepository> _cargoRepository;
        private readonly Lazy<ICargoMovementRepository> _cargoMovementRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(_context));
            _addressRepository = new Lazy<IAddressRepository>(() => new AddressRepository(_context));
            _customerAdressRepository = new Lazy<ICustomerAdressRepository>(() => new CustomerAddressRepository(_context));
            _customerMobilRepository = new Lazy<ICustomerMobilRepository>(() => new CustomerMobilRepository(_context));
            _branchRepository = new Lazy<IBranchRepository>(() => new BranchRepository(_context));
            _receiverRepository = new Lazy<IReceiverRepository>(() => new ReceiverRepository(_context));
            _countryRepository = new Lazy<ICountryRepository>(() => new CountryRepository(_context));
            _provinceRepository = new Lazy<IProvinceRepository>(() => new ProvinceRepository(_context));
            _districtRepository = new Lazy<IDistrictRepository>(() => new DistrictRepository(_context));
            _neighbourhoodRepository = new Lazy<INeighbourhoodRepository>(() => new NeighbourhoodRepository(_context));
            _cargoStatusRepository = new Lazy<ICargoStatusRepository>(() => new CargoStatusRepository(_context));
            _cargoTransportationConditionsRepository = new Lazy<ICargoTransportationConditionsRepository>(() => new CargoTransportationConditionsRepository(_context));
            _paymentTypeRepository = new Lazy<IPaymentTypeRepository>(() => new PaymentTypeRepository(_context));
            _cargoTypeRepository = new Lazy<ICargoTypeRepository>(() => new CargoTypeRepository(_context));
            _callCourierRepository = new Lazy<ICallCourierRepository>(() => new CallCourierRepository(_context));
            _cargoParcelType = new Lazy<ICargoParcelType>(() => new CargoParcelTypeRepository(_context));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeesRepository(_context));
            _employeeTypeRepository = new Lazy<IEmployeeTypeRepository>(() => new EmployeeTypeRepository(_context));
            _cargoRepository = new Lazy<ICargoRepository>(() => new CargoRepository(_context));
            _cargoMovementRepository = new Lazy<ICargoMovementRepository>(() => new CargoMovementRepository(_context));
        }

        public ICustomerRepository Customer => _customerRepository.Value;

        public IAddressRepository Address => _addressRepository.Value;

        public ICustomerAdressRepository CustomerAdress => _customerAdressRepository.Value;

        public ICustomerMobilRepository CustomerMobil => _customerMobilRepository.Value;

        public IBranchRepository Branch => _branchRepository.Value;

        public IReceiverRepository Reciever => _receiverRepository.Value;

        public ICountryRepository Country => _countryRepository.Value;

        public IProvinceRepository Province => _provinceRepository.Value;

        public IDistrictRepository District => _districtRepository.Value;

        public INeighbourhoodRepository Neighbourhood => _neighbourhoodRepository.Value;

        public ICargoStatusRepository CargoStatus => _cargoStatusRepository.Value;

        public ICargoTransportationConditionsRepository CargoTransportationConditions => _cargoTransportationConditionsRepository.Value;

        public IPaymentTypeRepository PaymentType => _paymentTypeRepository.Value;

        public ICargoTypeRepository CargoType => _cargoTypeRepository.Value;

        public ICallCourierRepository CallCourier => _callCourierRepository.Value;

        public ICargoParcelType CargoParcelType => _cargoParcelType.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public IEmployeeTypeRepository EmployeeType => _employeeTypeRepository.Value;

        public ICargoRepository Cargo => _cargoRepository.Value;

        public ICargoMovementRepository CargoMovement => _cargoMovementRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
