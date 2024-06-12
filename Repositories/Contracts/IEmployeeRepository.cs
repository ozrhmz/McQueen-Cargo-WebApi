using Entities.Models;

namespace Repositories.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employees>
    {
        Task<IEnumerable<Employees>> GetAllEmployeesAsync();
        Task<Employees> GetOneEmployeeByIdAsync(int id, bool trackChanges);
        Task<Employees> GetOneEmployeeByTcNoAsync(string TcNo, bool trackChanges);
        void CreateOneEmployee(Employees employee);
        void UpdateOneEmployee(Employees employee);
        void DeleteOneEmployee(Employees employee);
        Task<Employees> LoginGetOneEmployeeByTCNoAsync(string TcNo, bool trackChanges);
        Task<IEnumerable<Address>> GetCargoesByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<Address>> GetCargoesOkByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<CustomerMobil>> GetCustomerInfoWithAddressIdAsync(List<int> addressIds);
    }
}
