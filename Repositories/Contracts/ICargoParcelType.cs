using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICargoParcelType
    {
        Task<IEnumerable<CargoParcelType>> GetAllCargoParcelType();
    }
}
