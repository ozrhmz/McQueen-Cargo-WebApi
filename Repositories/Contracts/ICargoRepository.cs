using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICargoRepository
    {
        Task<IEnumerable<Cargo>> GetAllCargoAsync();
        Task<List<Cargo>> GetAllCargoByTCNoAsync(string TCNo, bool trackChanges);
        Task<Cargo> GetOneCargoByIdAsync(int id, bool trackChanges);
        Task<Cargo> GetOneCargoByTrackingNoAsync(string trackingNo, bool trackChanges);
        void CreateOneCargo(Cargo cargo);
        void CreateOneCargoForCallCourier(Cargo cargo);
        void UpdateOneCargo(Cargo cargo);
        void DeleteOneCargo(Cargo cargo);
    }
}
