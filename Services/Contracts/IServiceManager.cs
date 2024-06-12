namespace Services.Contracts
{
    public interface IServiceManager
    {
        ICustomerService CustomerService { get; }
        IAddressService AddressService { get; }
        ICustomerMobilService CustomerMobilService { get; }
        IBranchService BranchService { get; }
        IReceiverService ReceiverService { get; }
        ICountryService CountryService { get; }
        IProvinceService ProvinceService { get; }
        IDistrictService DistrictService { get; }
        INeighbourhoodService NeighbourhoodService { get; }
        ICargoStatusService CargoStatusService { get; }
        ICargoTransportationConditionsService CargoTransportationConditions { get; }
        IPaymentTypeService PaymentTypeService { get; }
        ICargoTypeService CargoTypeService { get; }
        ICallCourierService CallCourierService { get; }
        ICargoParcelTypeService CargoParcelTypeService { get; }
        IEmployeeService EmployeeService { get; }
        IEmployeeTypeService EmployeeTypeService { get; }
        ICargoService CargoService { get; }
        ICargoMovementService CargoMovementService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
