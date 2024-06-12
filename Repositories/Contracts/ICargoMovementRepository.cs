using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICargoMovementRepository : IRepositoryBase<CargoMovement>
    {
        Task<IEnumerable<CargoMovement>> GetAllCargoMovementAsync();
        Task<CargoMovement> GetOneCargoMovementByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<CargoMovement>> GetOneCargoMovementWithCargoByIdAsync(int id, bool trackChanges);
        void CreateOneCargoMovement(CargoMovement cargomovement);
        void UpdateOneCargoMovement(CargoMovement cargomovement);
        void DeleteOneCargoMovement(CargoMovement cargomovement);
    }
}
