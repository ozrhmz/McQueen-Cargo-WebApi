namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICustomerRepository Customer { get; }
        ICustomerMobilRepository CustomerMobil { get; }
        IAddressRepository Address { get; }
        ICustomerAdressRepository CustomerAdress { get; }
        IBranchRepository Branch { get; }
        IReceiverRepository Reciever { get; }
        ICountryRepository Country { get; }
        IProvinceRepository Province { get; }
        IDistrictRepository District { get; }
        INeighbourhoodRepository Neighbourhood { get; }
        ICargoStatusRepository CargoStatus { get; }
        ICargoTransportationConditionsRepository CargoTransportationConditions { get; }
        IPaymentTypeRepository PaymentType { get; }
        ICargoTypeRepository CargoType { get; }
        ICallCourierRepository CallCourier { get; }
        ICargoParcelType CargoParcelType { get; }
        IEmployeeRepository Employee { get; }
        IEmployeeTypeRepository EmployeeType { get; }
        ICargoRepository Cargo { get; }
        ICargoMovementRepository CargoMovement { get; }
        Task SaveAsync();
    }
}
