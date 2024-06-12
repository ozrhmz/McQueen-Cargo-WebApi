using AutoMapper;
using Entities.DTO_s.CargoStatus;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CargoParcelTypeManager : ICargoParcelTypeService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CargoParcelTypeManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public async Task<IEnumerable<CargoParcelTypeDto>> GetAllCargoParcelType()
        {
            var CargoParcelType = await _manager.CargoParcelType.GetAllCargoParcelType();
            var CargoParcelTypeDto = _mapper.Map<IEnumerable<CargoParcelTypeDto>>(CargoParcelType);
            return CargoParcelTypeDto;

        }
    }
}
