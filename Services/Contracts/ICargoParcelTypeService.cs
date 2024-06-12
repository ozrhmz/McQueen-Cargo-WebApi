using Entities.DTO_s.CargoStatus;

namespace Services.Contracts
{
    public interface ICargoParcelTypeService
    {
        Task<IEnumerable<CargoParcelTypeDto>> GetAllCargoParcelType();
    }
}
