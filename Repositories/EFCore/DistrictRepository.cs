using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class DistrictRepository : RepositoryBase<District>, IDistrictRepository
    {
        public DistrictRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<District>> GetAllDistrict()
        {
            return await _context.District.ToListAsync();
        }
    }
}
