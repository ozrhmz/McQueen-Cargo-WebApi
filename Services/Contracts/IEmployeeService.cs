using Entities.DTO_s;
using Entities.DTO_s.CallCourier;
using Entities.DTO_s.Cargo;
using Entities.DTO_s.CustomerMobil;
using Entities.DTO_s.Employee;
using Entities.Models;

namespace Services.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetOneEmployeeByIdAsync(int id, bool trackChanges);
        Task<EmployeeDto> GetOneEmployeeByTcNoAsync(string TcNo, bool trackChanges);
        Task<EmployeeDto> CreateOneEmployeeAsync(EmployeeDtoForInsertion employeeDto);
        Task UpdateOneEmployeeAsync(int id, EmployeeDtoForUpdate employeeDto, bool trackChanges);
        Task DeleteOneEmployeeAsync(int id, bool trackChanges);
        Task<EmployeeDto> UserLoginAsync(string userName, string password);
        Task<List<CallCourierDto>> GetCargoesByEmployeeIdAsync(int EmployeeId);
        Task<IEnumerable<CargoDto>> GetCargoesOkByEmployeeIdAsync(int EmployeeId);
    }
}
