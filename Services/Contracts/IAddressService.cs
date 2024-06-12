
using Entities.DTO_s;
using Entities.RequestFeatures;
using System.Dynamic;

namespace Services.Contracts
{
    public interface IAddressService
    {
        Task<IEnumerable<ExpandoObject>> GetAllAddressesAsync(AddressParameters addressParameters, bool trackChanges);
        Task<AddressDto> GetOneAddressByIdAsync(int id, bool trackChanges);
        Task<AddressDto> GetOneAddressWithCustomerIdAsync(int customerId, int addressId, bool trackChanges);
        Task<IEnumerable<AddressDto>> GetOneCustomerIdWithAddress(int customerId, bool trackChanges);
        Task<IEnumerable<AddressDto>> GetOneCustomerMobilIdWithAddress(int customerId, bool trackChanges);
        Task<IEnumerable<AddressDto>> GetOneBranchIdWithAddress(int branchId, bool trackChanges);
        Task<AddressDto> CreateOneAddressAsync(AddressDtoForInsertion addressDto, int customerId);
        Task<AddressDto> CreateOneAddressMobilAsync(AddressDtoForInsertion addressDto, int customerMobilId);
        Task<AddressDto> CreateOneAddressBranchAsync(AddressDtoForInsertion addressDto, int branchId);
        Task UpdateOneAddressAsync(int id, AddressDtoForUpdate addressDto, bool trackChanges);
        Task DeleteOneAddressAsync(int id, bool trackChanges);
    }
}
