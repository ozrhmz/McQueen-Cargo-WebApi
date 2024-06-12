using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CargoParcelTypeRepository : RepositoryBase<CargoParcelType>, ICargoParcelType
    {
        public CargoParcelTypeRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CargoParcelType>> GetAllCargoParcelType()
        {
            return await _context.CargoParcelType.ToListAsync();
        }
    }
}
