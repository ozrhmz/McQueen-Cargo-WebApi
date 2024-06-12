using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class ProvinceRepository : RepositoryBase<Province>, IProvinceRepository
    {
        public ProvinceRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Province>> GetAllProvince()
        {
            return await _context.Province.ToListAsync();
        }
    }
}
