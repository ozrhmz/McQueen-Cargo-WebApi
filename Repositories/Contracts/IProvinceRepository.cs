using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProvinceRepository
    {
        Task<IEnumerable<Province>> GetAllProvince();
    }
}
