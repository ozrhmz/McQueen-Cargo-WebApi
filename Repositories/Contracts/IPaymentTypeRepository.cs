using Entities.Models;

namespace Repositories.Contracts
{
    public interface IPaymentTypeRepository
    {
        Task<IEnumerable<PaymentType>> GetAllPaymentType();
    }
}
