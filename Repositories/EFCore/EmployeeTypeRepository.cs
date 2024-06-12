using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class EmployeeTypeRepository : RepositoryBase<EmployeesType>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeesType>> GetAllEmployeeType()
        {
            return await _context.EmployeesType.ToListAsync();
        }
    }
}
