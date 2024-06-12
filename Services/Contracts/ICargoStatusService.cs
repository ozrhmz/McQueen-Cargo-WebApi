using Entities.DTO_s.CargoStatus;

namespace Services.Contracts
{
    public interface ICargoStatusService
    {
        Task<IEnumerable<CargoStatusDto>> GetAllCargoStatus();
    }
}
