using AutoMapper;
using Entities.DTO_s.Address;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class NeighbourhoodManager : INeighbourhoodService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public NeighbourhoodManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public async Task<IEnumerable<NeighbourhoodDto>> GetAllNeighbourhood(int DistrictId)
        {
            var Neighbourhouds = await _manager.Neighbourhood.GetlAllNeighbourhood(DistrictId);
            var NeighbourhoudsDto = _mapper.Map<IEnumerable<NeighbourhoodDto>>(Neighbourhouds);
            return NeighbourhoudsDto;
        }
    }
}
