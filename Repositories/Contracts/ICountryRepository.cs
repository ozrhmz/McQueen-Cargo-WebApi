using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountry();
    }
}
