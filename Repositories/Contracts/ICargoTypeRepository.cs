using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICargoTypeRepository
    {
        Task<IEnumerable<CargoType>> GetAllCargoType();
    }
}
