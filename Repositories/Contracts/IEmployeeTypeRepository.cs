using Entities.Models;

namespace Repositories.Contracts
{
    public interface IEmployeeTypeRepository
    {
        Task<IEnumerable<EmployeesType>> GetAllEmployeeType();
    }
}
