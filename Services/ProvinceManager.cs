using AutoMapper;
using Entities.DTO_s.Address;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProvinceManager : IProvinceService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProvinceManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public async Task<IEnumerable<ProvinceDto>> GetAllProvince()
        {
            var Provinces = await _manager.Province.GetAllProvince();
            var ProvincesDto = _mapper.Map<IEnumerable<ProvinceDto>>(Provinces);
            return ProvincesDto;
        }
    }
}
