using Entities.DTO_s.Address;

namespace Services.Contracts
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllCountry();
    }
}
