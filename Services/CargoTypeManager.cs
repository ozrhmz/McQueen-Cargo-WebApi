using AutoMapper;
using Entities.DTO_s.CargoStatus;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CargoTypeManager : ICargoTypeService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CargoTypeManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CargoTypeDto>> GetAllCargoType()
        {
            var CargoType = await _manager.CargoType.GetAllCargoType();
            var CargoTypeDto = _mapper.Map<IEnumerable<CargoTypeDto>>(CargoType);
            return CargoTypeDto;
        }
    }
}
