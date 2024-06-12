using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Country>> GetAllCountry()
        {
            return await _context.Country.ToListAsync();
        }
    }
}
