using Entities.DTO_s.Address;

namespace Services.Contracts
{
    public interface IDistrictService
    {
        Task<IEnumerable<DistrictDto>> GetAllDistrict();
    }
}
