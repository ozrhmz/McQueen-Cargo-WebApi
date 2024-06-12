using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class PaymentTypeRepository : RepositoryBase<PaymentType>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PaymentType>> GetAllPaymentType()
        {
            return await _context.PaymentType.ToListAsync();
        }
    }
}
