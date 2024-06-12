using Entities.DTO_s.CargoStatus;

namespace Services.Contracts
{
    public interface ICargoTypeService
    {
        Task<IEnumerable<CargoTypeDto>> GetAllCargoType();
    }
}
