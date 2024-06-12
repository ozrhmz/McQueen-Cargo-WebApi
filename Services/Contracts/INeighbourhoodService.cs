using Entities.DTO_s.Address;

namespace Services.Contracts
{
    public interface INeighbourhoodService
    {
        Task<IEnumerable<NeighbourhoodDto>> GetAllNeighbourhood(int DistrictId);
    }
}
