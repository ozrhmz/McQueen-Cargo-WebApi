using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CargoStatusRepository : RepositoryBase<CargoStatus>, ICargoStatusRepository
    {
        public CargoStatusRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CargoStatus>> GetAllCargoStatus()
        {
            return await _context.CargoStatus.ToListAsync();
        }
    }
}
