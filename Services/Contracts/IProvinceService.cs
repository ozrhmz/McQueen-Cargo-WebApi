using Entities.DTO_s.Address;

namespace Services.Contracts
{
    public interface IProvinceService
    {
        Task<IEnumerable<ProvinceDto>> GetAllProvince();
    }
}
