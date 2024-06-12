using AutoMapper;
using Entities.DTO_s.CallCourier;
using Entities.DTO_s.Cargo;
using Entities.DTO_s.Employee;
using Entities.Exceptions.NotFoundExceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;

        public EmployeeManager(IRepositoryManager manager, IMapper mapper, ILoggerService logger)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
        }

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public async Task<EmployeeDto> CreateOneEmployeeAsync(EmployeeDtoForInsertion employeeDto)
        {
            var entity = _mapper.Map<Employees>(employeeDto);
            entity.Password = EncryptPassword(employeeDto.Password);
            _manager.Employee.CreateOneEmployee(entity);
            await _manager.SaveAsync();

            return _mapper.Map<EmployeeDto>(entity);
        }

        public async Task DeleteOneEmployeeAsync(int id, bool trackChanges)
        {
            var entity = await GetOneEmployeeAndCheckExist(id, trackChanges);
            _manager.Employee.DeleteOneEmployee(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _manager.Employee.GetAllEmployeesAsync();
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return employeesDto;
        }

        public async Task<EmployeeDto> GetOneEmployeeByIdAsync(int id, bool trackChanges)
        {
            var employee = await GetOneEmployeeAndCheckExist(id, trackChanges);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> GetOneEmployeeByTcNoAsync(string TcNo, bool trackChanges)
        {
            var entity = await _manager.Employee.GetOneEmployeeByTcNoAsync(TcNo, trackChanges);
            if (entity is null)
                throw new EmployeeNotFoundExceptions();
            return _mapper.Map<EmployeeDto>(entity);
        }

        public async Task UpdateOneEmployeeAsync(int id, EmployeeDtoForUpdate employeeDto, bool trackChanges)
        {
            var entity = await GetOneEmployeeAndCheckExist(id, trackChanges);
            entity = _mapper.Map<Employees>(employeeDto);
            _manager.Employee.Update(entity);
            await _manager.SaveAsync();
        }
        private async Task<Employees> GetOneEmployeeAndCheckExist(int id, bool trackChanges)
        {
            var entity = await _manager.Employee.GetOneEmployeeByIdAsync(id, trackChanges);
            if (entity is null)
                throw new EmployeeNotFoundExceptions(id);
            return entity;
        }

        public async Task<EmployeeDto> UserLoginAsync(string TcNo, string password)
        {
            var userByTCNo = await _manager.Employee.LoginGetOneEmployeeByTCNoAsync(TcNo, false);
            return await ValidateUser(userByTCNo, password);
        }

        private async Task<EmployeeDto> ValidateUser(Employees user, string password)
        {
            if (user != null && VerifyPassword(password, user.Password))
            {
                var customerMobil = _mapper.Map<EmployeeDto>(user);
                return customerMobil;
            }
            return null;
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] enteredBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
                StringBuilder enteredSB = new StringBuilder();
                for (int i = 0; i < enteredBytes.Length; i++)
                {
                    enteredSB.Append(enteredBytes[i].ToString("x2"));
                }

                return enteredSB.ToString() == storedPassword;
            }
        }

        //Kötü Kod Değişecek
        public async Task<List<CallCourierDto>> GetCargoesByEmployeeIdAsync(int EmployeeId)
        {
            var Result = new List<CallCourier>();
            var emplooye = await _manager.Employee.GetOneEmployeeByIdAsync(EmployeeId, false);
            var CallCourierList = await _manager.CallCourier.GetAllCallCarierAsync(); //GetAll Yerine farklı bir metod yazılacak.
            if ((CallCourierList != null && CallCourierList.ToList().Count > 0) && emplooye != null)
            {
                CallCourierList = CallCourierList.Where(x => x.CallCourierOk == false).ToList();
                foreach (var item in CallCourierList)
                {
                    if(item.CustomerMobilAdressId != 0)
                    {
                        var address = await _manager.Address.GetOneAddressByIdAsync(item.CustomerMobilAdressId,false);
                        if(address != null && address.DistrictId == emplooye.BranchId)
                        {
                            Result.Add(item);
                        }
                    }
                }
            }
            var ReturnListDto = _mapper.Map<List<CallCourierDto>>(Result);
            return ReturnListDto;
        }

        public async Task<IEnumerable<CargoDto>> GetCargoesOkByEmployeeIdAsync(int EmployeeId)
        {
            //Kod düzeltilicek
            var emplooye = await _manager.Employee.GetOneEmployeeByIdAsync(EmployeeId, false);
            var CargoList = await _manager.Cargo.GetAllCargoAsync(); //GetAll Yerine farklı bir metod yazılacak.
            if ((CargoList != null && CargoList.ToList().Count > 0) && emplooye != null)
            {
                DateTime targetDate = DateTime.Now.Date;
                CargoList = CargoList
                    .Where(x => x.CargoDepartureBranchId == emplooye.BranchId && x.CargoReleaseDate.Date == targetDate)
                    .ToList();
            }
            var result = _mapper.Map<IEnumerable<CargoDto>>(CargoList);
            return result;
        }
    }
}
