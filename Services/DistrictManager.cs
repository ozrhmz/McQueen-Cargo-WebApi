using AutoMapper;
using Entities.DTO_s.Address;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class DistrictManager : IDistrictService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public DistrictManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public async Task<IEnumerable<DistrictDto>> GetAllDistrict()
        {
            var Districts = await _manager.District.GetAllDistrict();
            var DistrictsDto = _mapper.Map<IEnumerable<DistrictDto>>(Districts);
            return DistrictsDto;
        }
    }
}
