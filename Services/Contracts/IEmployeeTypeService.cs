using Entities.DTO_s.Employee;

namespace Services.Contracts
{
    public interface IEmployeeTypeService
    {
        Task<IEnumerable<EmployeeTypeDto>> GetAllEmployeeType();
    }
}
