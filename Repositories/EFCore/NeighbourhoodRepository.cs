using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class NeighbourhoodRepository : RepositoryBase<Neighbourhood>, INeighbourhoodRepository
    {
        public NeighbourhoodRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Neighbourhood>> GetlAllNeighbourhood(int DisctrictId)
        {
            return await _context.Neighbourhood.Where(x => x.DistrictId == DisctrictId).ToListAsync();
        }
    }
}
