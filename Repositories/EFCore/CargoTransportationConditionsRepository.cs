using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CargoTransportationConditionsRepository : RepositoryBase<CargoTransportationConditions>, ICargoTransportationConditionsRepository
    {
        public CargoTransportationConditionsRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CargoTransportationConditions>> GetAllCargoTransportationConditions()
        {
            return await _context.CargoTransportationConditions.ToListAsync();
        }
    }
}
