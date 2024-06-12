using AutoMapper;
using Entities.DTO_s;
using Entities.DTO_s.Address;
using Entities.DTO_s.Auth;
using Entities.DTO_s.Branch;
using Entities.DTO_s.CallCourier;
using Entities.DTO_s.Cargo;
using Entities.DTO_s.CargoStatus;
using Entities.DTO_s.CustomerAddress;
using Entities.DTO_s.CustomerMobil;
using Entities.DTO_s.Employee;
using Entities.DTO_s.Receiver;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Customer Mapping
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDtoForUpdate, Customer>().ReverseMap();
            CreateMap<CustomerDtoForInsertion, Customer>();
            #endregion

            #region Customer Mobil Mapping
            CreateMap<CustomerMobil, CustomerMobilDto>();
            CreateMap<CustomerMobilDtoForUpdate, CustomerMobil>().ReverseMap();
            CreateMap<CustomerMobilDtoForInsertion, CustomerMobil>();
            #endregion

            #region Address Mapping
            CreateMap<Address, AddressDto>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.CountryName))
                .ForMember(dest => dest.ProvinceName, opt => opt.MapFrom(src => src.Province.ProvinceName))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.DistrictName))
                .ForMember(dest => dest.NeighbourhoodName, opt => opt.MapFrom(src => src.Neighbourhood.NeighbourhoodName));
            CreateMap<AddressDtoForInsertion, Address>();
            CreateMap<AddressDtoForUpdate, Address>().ReverseMap();
            CreateMap<CustomerAddress, AddressDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Province, ProvinceDto>().ReverseMap();
            CreateMap<District, DistrictDto>().ReverseMap();
            CreateMap<Neighbourhood, NeighbourhoodDto>().ReverseMap();
            #endregion

            #region Branch Mapping
            CreateMap<Branch, BranchDto>();
            CreateMap<BranchDtoForInsertion, Branch>().ReverseMap();
            CreateMap<BranchDtoForUpdate, Branch>();
            #endregion

            #region Receiver Mapping
            CreateMap<Receiver, ReceiverDto>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.CountryName))
                .ForMember(dest => dest.ProvinceName, opt => opt.MapFrom(src => src.Province.ProvinceName))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.DistrictName))
                .ForMember(dest => dest.NeighbourhoodName, opt => opt.MapFrom(src => src.Neighbourhood.NeighbourhoodName));
            CreateMap<ReceiverDtoForInsertion, Receiver>().ReverseMap();
            CreateMap<ReceiverDtoForUpdate, Receiver>();
            #endregion

            #region Cargo Mapping
            CreateMap<CargoStatus, CargoStatusDto>();
            CreateMap<CargoTransportationConditions, CargoTransportationConditionsDto>();
            CreateMap<PaymentType, PaymentTypeDto>();
            CreateMap<CargoType, CargoTypeDto>(); CreateMap<Cargo, CargoDto>()
                .ForMember(dest => dest.ReceiverNameSurname, opt => opt.MapFrom(src => src.Receiver.NameSurname))
                .ForMember(dest => dest.ReceiverCountryName, opt => opt.MapFrom(src => src.Receiver.Country.CountryName))
                .ForMember(dest => dest.ReceiverProvinceName, opt => opt.MapFrom(src => src.Receiver.Province.ProvinceName))
                .ForMember(dest => dest.ReceiverDistrictName, opt => opt.MapFrom(src => src.Receiver.District.DistrictName))
                .ForMember(dest => dest.ReceiverNeighbourhoodName, opt => opt.MapFrom(src => src.Receiver.Neighbourhood.NeighbourhoodName))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerMobil.Name))
                .ForMember(dest => dest.CustomerSurname, opt => opt.MapFrom(src => src.CustomerMobil.Surname))
                .ForMember(dest => dest.CargoArrivalBranchName, opt => opt.MapFrom(src => src.CargoArrivalBranch.BranchName))
                .ForMember(dest => dest.CargoDepartureBranchName, opt => opt.MapFrom(src => src.CargoDepartureBranch.BranchName))
                .ForMember(dest => dest.CargoTransportationConditionsName, opt => opt.MapFrom(src => src.CargoTransportationConditions.CargoTransportationConditionsName))
                .ForMember(dest => dest.CargoTransportationConditionsName, opt => opt.MapFrom(src => src.CargoTransportationConditions.CargoTransportationConditionsName))
                .ForMember(dest => dest.CargoTypeName, opt => opt.MapFrom(src => src.CargoType.CargoTypeName))
                .ForMember(dest => dest.PaymentTypeName, opt => opt.MapFrom(src => src.PaymentType.PaymentTypeName))
                .ForMember(dest => dest.CargoParcelTypeName, opt => opt.MapFrom(src => src.cargoParcelType.CargoParcelTypeName))
                .ForMember(dest => dest.CargoStatusName, opt => opt.MapFrom(src => src.CargoStatus.ShippingStatusName))
                .ForMember(dest => dest.Floor, opt => opt.MapFrom(src => src.Receiver.Floor));
            CreateMap<CargoDtoForInsertion, Cargo>().ReverseMap();
            CreateMap<CargoDtoForUpdate, Cargo>().ReverseMap();
            CreateMap<CargoMovement, CargoMovementDto>()
                .ForMember(dest => dest.CargoBranchName, opt => opt.MapFrom(src => src.Branch.BranchName))
                .ForMember(dest => dest.CargoTrackingNo, opt => opt.MapFrom(src => src.Cargo.CargoTrackingNo))
                .ForMember(dest => dest.CargoStatusName, opt => opt.MapFrom(src => $"{src.CargoStatus.ShippingStatusName}; {src.CargoStatus.Information}"));
            CreateMap<CargoParcelType, CargoParcelTypeDto>().ReverseMap();
            CreateMap<CargoMovementDto, CargoMovement>();
            #endregion

            #region CallCourier Mapping
            CreateMap<CallCourier, CallCourierDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerMobil.Name))
                .ForMember(dest => dest.CustomerSurname, opt => opt.MapFrom(src => src.CustomerMobil.Surname))
                .ForMember(dest => dest.CargoTransportationConditionsName, opt => opt.MapFrom(src => src.CargoTransportationConditions.CargoTransportationConditionsName))
                .ForMember(dest => dest.CargoTypeName, opt => opt.MapFrom(src => src.CargoType.CargoTypeName))
                .ForMember(dest => dest.PaymentTypeName, opt => opt.MapFrom(src => src.PaymentType.PaymentTypeName))
                .ForMember(dest => dest.CargoParcelTypeName, opt => opt.MapFrom(src => src.CargoParcelType.CargoParcelTypeName))
                .ForMember(dest => dest.ReceiverCountryName, opt => opt.MapFrom(src => src.Receiver.Country.CountryName))
                .ForMember(dest => dest.ReceiverProvinceName, opt => opt.MapFrom(src => src.Receiver.Province.ProvinceName))
                .ForMember(dest => dest.ReceiverDistrictName, opt => opt.MapFrom(src => src.Receiver.District.DistrictName))
                .ForMember(dest => dest.ReceiverNeighbourhoodName, opt => opt.MapFrom(src => src.Receiver.Neighbourhood.NeighbourhoodName))
                .ForMember(dest => dest.Floor, opt => opt.MapFrom(src => src.Receiver.Floor));
            CreateMap<CallCourierDtoForInsertion, CallCourier>().ReverseMap();
            CreateMap<CallCourierDtoForUpdate, CallCourier>().ReverseMap();
            #endregion

            #region Employee Mapping
            CreateMap<Employees, EmployeeDto>();
            CreateMap<EmployeeDtoForInsertion, Employees>().ReverseMap();
            CreateMap<EmployeeDtoForUpdate, Employees>();
            CreateMap<EmployeesType, EmployeeTypeDto>().ReverseMap();
            #endregion

            #region User Mapping
            CreateMap<UserForRegistrationDto, User>();
            #endregion
        }
    }
}
