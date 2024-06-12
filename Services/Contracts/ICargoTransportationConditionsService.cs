using Entities.DTO_s.CargoStatus;

namespace Services.Contracts
{
    public interface ICargoTransportationConditionsService
    {
        Task<IEnumerable<CargoTransportationConditionsDto>> GetAllCargoTransCon();
    }
}
