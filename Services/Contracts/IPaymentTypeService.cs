using Entities.DTO_s.CargoStatus;

namespace Services.Contracts
{
    public interface IPaymentTypeService
    {
        Task<IEnumerable<PaymentTypeDto>> GetAllPaymentType();
    }
}
