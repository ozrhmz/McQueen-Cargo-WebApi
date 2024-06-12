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
    public class AddressManager : IAddressService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;
        private readonly IDataShaper<AddressDto> _shaper;

        public AddressManager(IRepositoryManager manager, IMapper mapper, ILoggerService logger, IDataShaper<AddressDto> shaper)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
            _shaper = shaper;
        }

        public async Task<AddressDto> CreateOneAddressAsync(AddressDtoForInsertion addressDto, int customerId)
        {
            //İf sorgularında Province Country gibi verilere ait ıd varmı sorguları için diğer tablolar adına CRUD işlemi yapıalcak.

            var entity = _mapper.Map<Address>(addressDto);
            _manager.Address.CreateOneAddress(entity);
            await _manager.SaveAsync();

            _manager.CustomerAdress.CreateOneAddress(customerId, entity.Id);
            await _manager.SaveAsync();

            return _mapper.Map<AddressDto>(entity);
        }

        public async Task<AddressDto> CreateOneAddressBranchAsync(AddressDtoForInsertion addressDto, int branchId)
        {
            var entity = _mapper.Map<Address>(addressDto);
            _manager.Address.CreateOneAddress(entity);
            await _manager.SaveAsync();

            _manager.CustomerAdress.CreateOneAdressBranch(branchId, entity.Id);
            await _manager.SaveAsync();

            return _mapper.Map<AddressDto>(entity);
        }

        public async Task<AddressDto> CreateOneAddressMobilAsync(AddressDtoForInsertion addressDto, int customerMobilId)
        {
            var entity = _mapper.Map<Address>(addressDto);
            _manager.Address.CreateOneAddress(entity);
            await _manager.SaveAsync();

            _manager.CustomerAdress.CreateOneAdressMobil(customerMobilId, entity.Id);
            await _manager.SaveAsync();

            return _mapper.Map<AddressDto>(entity);
        }

        public async Task DeleteOneAddressAsync(int id, bool trackChanges)
        {
            var entity = await GetOneAddressAndCheckExist(id, trackChanges);
            _manager.CustomerAdress.DeleteAdress(entity.CustomerAddresses);
            _manager.Address.DeleteOneAddress(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<ExpandoObject>> GetAllAddressesAsync(AddressParameters addressParameters, bool trackChanges)
        {
            var addresses = await _manager.Address.GetAllAddressesAsync(addressParameters, trackChanges);
            var addressDtos = _mapper.Map<List<AddressDto>>(addresses);
            return _shaper.ShapeData(addressDtos, addressParameters.Fields);
        }

        public async Task<AddressDto> GetOneAddressByIdAsync(int id, bool trackChanges)
        {
            var address = await GetOneAddressAndCheckExist(id, trackChanges);
            var AddressDto = _mapper.Map<AddressDto>(address);
            return AddressDto;
        }

        public async Task<AddressDto> GetOneAddressWithCustomerIdAsync(int customerId, int addressId, bool trackChanges)
        {
            var address = await GetOneAddressCustomerAndCheckExist(customerId, addressId, trackChanges);
            var AddressDto = _mapper.Map<AddressDto>(address);
            return AddressDto;
        }

        public async Task<IEnumerable<AddressDto>> GetOneBranchIdWithAddress(int branchId, bool trackChanges)
        {
            var address = await _manager.Address.GetOneBranchIdWithAddress(branchId, trackChanges);
            var addressDtos = _mapper.Map<List<AddressDto>>(address);
            return addressDtos;
        }
        //Maplemeye tekrar bakılacak ve düzeltilecek.
        public async Task<IEnumerable<AddressDto>> GetOneCustomerIdWithAddress(int customerId, bool trackChanges)
        {
            var address = await _manager.Address.GetOneCustomerIdWithAddress(customerId, trackChanges);
            var addressDtos = new List<AddressDto>();

            foreach (var item in address)
            {
                var addressDto = new AddressDto
                {
                    Id = item.Id,
                    CountryId = item.Address.CountryId,
                    CountryName = item.Address.Country.CountryName,
                    ProvinceId = item.Address.ProvinceId,
                    ProvinceName = item.Address.Province.ProvinceName,
                    DistrictId = item.Address.DistrictId,
                    DistrictName = item.Address.District.DistrictName,
                    NeighbourhoodId = item.Address.NeighbourhoodId,
                    NeighbourhoodName = item.Address.Neighbourhood.NeighbourhoodName,
                    Street = item.Address.Street,
                    ApartmentNumber = item.Address.ApartmentNumber,
                    BuildingNo = item.Address.BuildingNo,
                    Floor = item.Address.Floor,
                    Title = item.Address.Title,
                    Description = item.Address.Description,
                };

                addressDtos.Add(addressDto);
            }
            return addressDtos;
        }
        //Maplemeye tekrar bakılacak ve düzeltilecek.
        public async Task<IEnumerable<AddressDto>> GetOneCustomerMobilIdWithAddress(int customerId, bool trackChanges)
        {
            var address = await _manager.Address.GetOneCustomerMobilIdWithAddress(customerId, trackChanges);
            var addressDtos = new List<AddressDto>();

            foreach (var item in address)
            {
                var addressDto = new AddressDto
                {
                    Id = item.Id,
                    CountryId = item.Address.CountryId,
                    CountryName = item.Address.Country.CountryName,
                    ProvinceId = item.Address.ProvinceId,
                    ProvinceName = item.Address.Province.ProvinceName,
                    DistrictId = item.Address.DistrictId,
                    DistrictName = item.Address.District.DistrictName,
                    NeighbourhoodId = item.Address.NeighbourhoodId,
                    NeighbourhoodName = item.Address.Neighbourhood.NeighbourhoodName,
                    Street = item.Address.Street,
                    ApartmentNumber = item.Address.ApartmentNumber,
                    BuildingNo = item.Address.BuildingNo,
                    Floor = item.Address.Floor,
                    Title = item.Address.Title,
                    Description = item.Address.Description
                };

                addressDtos.Add(addressDto);
            }
            return addressDtos;

        }

        public async Task UpdateOneAddressAsync(int id, AddressDtoForUpdate addressDto, bool trackChanges)
        {
            var entity = await GetOneAddressAndCheckExist(id, trackChanges);
            entity = _mapper.Map<Address>(addressDto);
            _manager.Address.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Address> GetOneAddressAndCheckExist(int id, bool trackChanges)
        {
            var entity = await _manager.Address.GetOneAddressByIdAsync(id, trackChanges);
            if (entity is null)
                throw new AddressNotFoundException(id);
            return entity;
        }

        private async Task<CustomerAddress> GetOneAddressCustomerAndCheckExist(int customerId, int addressId, bool trackChanges)
        {
            var entity = await _manager.Address.GetOneAddressWithCustomerIdAsync(customerId, addressId, trackChanges);
            if (entity is null)
                throw new AddressNotFoundWithCustomer(customerId, addressId);
            return entity;
        }
    }
}
