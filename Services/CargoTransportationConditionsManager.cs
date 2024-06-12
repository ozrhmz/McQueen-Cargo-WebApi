using AutoMapper;
using Entities.DTO_s.CargoStatus;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CargoTransportationConditionsManager : ICargoTransportationConditionsService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CargoTransportationConditionsManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CargoTransportationConditionsDto>> GetAllCargoTransCon()
        {
            var CargoTransCon = await _manager.CargoTransportationConditions.GetAllCargoTransportationConditions();
            var CargoTransConDto = _mapper.Map<IEnumerable<CargoTransportationConditionsDto>>(CargoTransCon);
            return CargoTransConDto;
        }
    }
}
