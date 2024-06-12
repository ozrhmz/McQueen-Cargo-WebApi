using Entities.Models;

namespace Repositories.Contracts
{
    public interface IDistrictRepository
    {
        Task<IEnumerable<District>> GetAllDistrict();
    }
}
