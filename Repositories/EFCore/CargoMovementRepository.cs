using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class CargoMovementRepository : RepositoryBase<CargoMovement>, ICargoMovementRepository
    {
        public CargoMovementRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCargoMovement(CargoMovement cargomovement)
        {
            var cargo = _context.Cargo.Where(x => x.Id == cargomovement.CargoId).FirstOrDefault();
            cargo.CargoStatusId = cargomovement.CargoStatusId;
            _context.Update(cargo);
            Create(cargomovement);
        }

        public void DeleteOneCargoMovement(CargoMovement cargomovement) => Delete(cargomovement);

        public async Task<IEnumerable<CargoMovement>> GetAllCargoMovementAsync()
        {
            return await _context.CargoMovement
                .Include(x => x.Cargo)
                .Include(x => x.CargoStatus)
                .Include(x => x.Branch)
                .ToListAsync();
        }

        public async Task<CargoMovement> GetOneCargoMovementByIdAsync(int id, bool trackChanges) =>
             await FindByCondition(c => c.Id.Equals(id), trackChanges)
                .Include(x => x.Cargo)
                .Include(x => x.CargoStatus)
                .Include(x => x.Branch)
                .SingleOrDefaultAsync();

        public async Task<IEnumerable<CargoMovement>> GetOneCargoMovementWithCargoByIdAsync(int id, bool trackChanges)
        {
            return await _context.CargoMovement.Where(x => x.CargoId == id)
                .Include(x => x.Cargo)
                .Include(x => x.CargoStatus)
                .Include(x => x.Branch)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public void UpdateOneCargoMovement(CargoMovement cargomovement) => Update(cargomovement);
    }
}
