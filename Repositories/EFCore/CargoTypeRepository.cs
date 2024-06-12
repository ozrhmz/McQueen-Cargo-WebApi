using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;


namespace Repositories.EFCore
{
    public class CargoTypeRepository : RepositoryBase<CargoType>, ICargoTypeRepository
    {
        public CargoTypeRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CargoType>> GetAllCargoType()
        {
            return await _context.CargoType.ToListAsync();
        }
    }
}
