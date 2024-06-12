using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICargoTransportationConditionsRepository
    {
        Task<IEnumerable<CargoTransportationConditions>> GetAllCargoTransportationConditions();
    }
}
