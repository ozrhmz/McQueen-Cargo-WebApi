using AutoMapper;
using Entities.DTO_s.Address;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CountryManager : ICountryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CountryManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public async Task<IEnumerable<CountryDto>> GetAllCountry()
        {
            var Countries = await _manager.Country.GetAllCountry();
            var CountriesDto = _mapper.Map<IEnumerable<CountryDto>>(Countries);
            return CountriesDto;
        }
    }
}
