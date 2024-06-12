using AutoMapper;
using Entities.DTO_s.CargoStatus;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CargoStatusManager : ICargoStatusService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CargoStatusManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CargoStatusDto>> GetAllCargoStatus()
        {
            var CargoStatus = await _manager.CargoStatus.GetAllCargoStatus();
            var CargoStatusDto = _mapper.Map<IEnumerable<CargoStatusDto>>(CargoStatus);
            return CargoStatusDto;
        }
    }
}
