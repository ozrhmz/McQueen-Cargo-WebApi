using Entities.DTO_s.CargoStatus;

namespace Services.Contracts
{
    public interface ICargoMovementService
    {
        Task<IEnumerable<CargoMovementDto>> GetAllCargoMovement();
        Task<CargoMovementDto> GetOneCargoMovementByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<CargoMovementDto>> GetOneCargoMovementWithCargoByIdAsync(int id, bool trackChanges);
        Task<CargoMovementDto> CreateOneCargoMovementAsync(CargoMovementDto cargoMovementDto);
        Task UpdateOneCargoMovementAsync(int id, CargoMovementDto cargoMovementDto, bool trackChanges);
        Task DeleteOneCargoMovementAsync(int id, bool trackChanges);
    }
}
