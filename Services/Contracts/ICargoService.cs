using Entities.DTO_s.CallCourier;
using Entities.DTO_s.Cargo;

namespace Services.Contracts
{
    public interface ICargoService
    {
        Task<IEnumerable<CargoDto>> GetAllCargo();
        Task<List<CargoDto>> GetAllCargoByTCNoAsync(string TCNo, bool trackChanges);
        Task<CargoDto> GetOneCargoByIdAsync(int id, bool trackChanges);
        Task<CargoDto> GetOneCargoByTrackingNoAsync(string trackingNo, bool trackChanges);
        Task<CargoDto> CreateOneCargoAsync(CargoDtoForInsertion cargoDto);
        Task<CargoDto> CreateOneCargoForCallCourierAsync(CallCourierDtoForUpdate callCourierDto);
        Task UpdateOneCargoAsync(int id, CargoDtoForUpdate cargoDto, bool trackChanges);
        Task DeleteOneCargoAsync(int id, bool trackChanges);
    }
}
