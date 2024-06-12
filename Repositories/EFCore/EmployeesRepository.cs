using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class EmployeesRepository : RepositoryBase<Employees>, IEmployeeRepository
    {
        public EmployeesRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneEmployee(Employees employee) => Create(employee);

        public void DeleteOneEmployee(Employees employee) => Delete(employee);

        public async Task<IEnumerable<Employees>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Address>> GetCargoesByEmployeeIdAsync(int employeeId)
        {
            var employeeBranchId = _context.Employees.Where(e => e.Id == employeeId).Select(e => e.Branch.DistrictId).FirstOrDefault();

            if (employeeBranchId == null)
            {
                return new List<Address>();
            }

            var customerAddressIds = _context.Cargo
                .Where(c=>c.CargoReleaseDate.Day == DateTime.Now.Day)
                .Select(c => c.CustomerMobilAdressId)
                .ToList();

            var cargoAddressIds = _context.CustomerAddress
                .Where(ca => customerAddressIds.Contains(ca.Id) && ca.AddressId > 0)
                .Select(ca => ca.AddressId)
                .ToList();

            var addresses = _context.Addresses
                .Where(a => cargoAddressIds.Contains(a.Id) && a.DistrictId == employeeBranchId)
                .Include(x => x.Country)
                .Include(x => x.Province)
                .Include(x => x.District)
                .Include(x => x.Neighbourhood)
                .ToList();

            return addresses;

        }

        public async Task<IEnumerable<Address>> GetCargoesOkByEmployeeIdAsync(int employeeId)
        {
            var employeeBranchId = _context.Employees.Where(e => e.Id == employeeId).Select(e => e.Branch.DistrictId).FirstOrDefault();

            if (employeeBranchId == null)
            {
                return new List<Address>();
            }

            var customerAddressIds = _context.CallCourier
                .Where(c => c.CallCourierOk && c.CargoRealeseDate.Day == DateTime.Now.Day)
                .Select(c => c.CustomerMobilAdressId)
                .ToList();

            var callCourierAddressIds = _context.CustomerAddress
                .Where(ca => customerAddressIds.Contains(ca.Id) && ca.AddressId > 0)
                .Select(ca => ca.AddressId)
                .ToList();

            var addresses = _context.Addresses
                .Where(a => callCourierAddressIds.Contains(a.Id) && a.DistrictId == employeeBranchId)
                .Include(x => x.Country)
                .Include(x => x.Province)
                .Include(x => x.District)
                .Include(x => x.Neighbourhood)
                .ToList();

            return addresses;
        }

        public async Task<IEnumerable<CustomerMobil>> GetCustomerInfoWithAddressIdAsync(List<int> addressIds)
        {
            var callcourierOk = _context.CallCourier
                .Where(x => x.CallCourierOk == true)
                .Select(x => x.CustomerMobilAdressId)
                .ToList();

            var customerMobilInfoList = _context.CustomerMobil
                .Where(x => callcourierOk.Contains(x.Id))
                .Include(x => x.CustomerAddresses)
                .ToList();

            return customerMobilInfoList.AsEnumerable();
        }

        public async Task<Employees> GetOneEmployeeByIdAsync(int id, bool trackChanges) =>
             await FindByCondition(e => e.Id.Equals(id), trackChanges)
                  .SingleOrDefaultAsync();

        public async Task<Employees> GetOneEmployeeByTcNoAsync(string TcNo, bool trackChanges) =>
            await FindByCondition(e => e.TcNo.Equals(TcNo), trackChanges)
                 .SingleOrDefaultAsync();

        public async Task<Employees> LoginGetOneEmployeeByTCNoAsync(string TcNo, bool trackChanges)
        {
            return await FindByCondition(c => c.TcNo.Equals(TcNo), trackChanges)
                        .SingleOrDefaultAsync();
        }

        public void UpdateOneEmployee(Employees employee) => Update(employee);
    }
}
