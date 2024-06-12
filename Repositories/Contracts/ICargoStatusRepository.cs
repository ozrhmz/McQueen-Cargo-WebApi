using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICargoStatusRepository
    {
        Task<IEnumerable<CargoStatus>> GetAllCargoStatus();
    }
}
