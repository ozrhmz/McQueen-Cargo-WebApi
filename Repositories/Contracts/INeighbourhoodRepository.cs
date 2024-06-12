using Entities.Models;

namespace Repositories.Contracts
{
    public interface INeighbourhoodRepository
    {
        Task<IEnumerable<Neighbourhood>> GetlAllNeighbourhood(int DisctrictId);
    }
}
