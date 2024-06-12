using AutoMapper;
using Entities.DTO_s.CargoStatus;
using Entities.Exceptions.NotFoundExceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CargoMovementManager : ICargoMovementService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public CargoMovementManager(IRepositoryManager manager, IMapper mapper, ILoggerService logger)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CargoMovementDto> CreateOneCargoMovementAsync(CargoMovementDto cargoMovementDto)
        {
            var entity = _mapper.Map<CargoMovement>(cargoMovementDto);
            _manager.CargoMovement.CreateOneCargoMovement(entity);
            await _manager.SaveAsync();
            return _mapper.Map<CargoMovementDto>(entity);
        }

        public async Task DeleteOneCargoMovementAsync(int id, bool trackChanges)
        {
            var entity = await _manager.CargoMovement.GetOneCargoMovementByIdAsync(id, trackChanges);
            if (entity is null)
                throw new CargoMovementNotFoundException(id);

            _manager.CargoMovement.DeleteOneCargoMovement(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<CargoMovementDto>> GetAllCargoMovement()
        {
            var CargoMovement = await _manager.CargoMovement.GetAllCargoMovementAsync();
            var CargoMovementDtos = _mapper.Map<List<CargoMovementDto>>(CargoMovement);
            return CargoMovementDtos;
        }

        public async Task<CargoMovementDto> GetOneCargoMovementByIdAsync(int id, bool trackChanges)
        {
            var item = await _manager.CargoMovement.GetOneCargoMovementByIdAsync(id, trackChanges);

            if (item is null)
                throw new CargoMovementNotFoundException(id);
            var CargoMov = _mapper.Map<CargoMovementDto>(item);
            return CargoMov;
        }

        public async Task<IEnumerable<CargoMovementDto>> GetOneCargoMovementWithCargoByIdAsync(int id, bool trackChanges)
        {
            var entity = await _manager.CargoMovement.GetOneCargoMovementWithCargoByIdAsync(id, trackChanges);
            if (entity is null)
                throw new CargoMovementNotFoundException(id);

            var CargoMovementDtos = _mapper.Map<List<CargoMovementDto>>(entity);
            return CargoMovementDtos;
        }

        public async Task UpdateOneCargoMovementAsync(int id, CargoMovementDto cargoMovementDto, bool trackChanges)
        {
            var entity = await _manager.CargoMovement.GetOneCargoMovementByIdAsync(id, trackChanges);
            if (entity is null)
                throw new CargoMovementNotFoundException(id);

            entity = _mapper.Map<CargoMovement>(cargoMovementDto);
            _manager.CargoMovement.Update(entity);
            await _manager.SaveAsync();
        }
    }
}
