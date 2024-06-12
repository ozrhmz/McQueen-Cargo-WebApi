using Entities.DTO_s.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Repositories.EFCore;
using Services.Contracts;

namespace Presentation.Controllers
{
    //[Authorize(Roles = "Admin,User")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public EmployeeController(IServiceManager manager, RepositoryContext context)
        {
            _manager = manager;
            _context = context;
        }

        [HttpGet(Name = "GetAllEmployeeAsync")]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {
            var employees = await _manager.EmployeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetOneEmployeeAsync([FromQuery(Name = "id")] int id)
        {
            var employee = await _manager
                .EmployeeService
                .GetOneEmployeeByIdAsync(id, false);

            return Ok(employee);
        }

        [HttpGet("TcNo")]
        public async Task<IActionResult> GetEmployeeWithTcNo([FromQuery(Name = "tcNo")] string tcNo)
        {
            var employee = await _manager
                            .EmployeeService
                            .GetOneEmployeeByTcNoAsync(tcNo, false);

            if (employee == null)
                return NotFound($"Employee {tcNo} is not found");

            return Ok(employee);
        }


        [HttpGet("EmployeeId")]
        public async Task<IActionResult> GetCargoesByEmployeeId([FromQuery(Name = "EmployeeId")] int EmployeeId)
        {
            var AddressesList = await _manager
                            .EmployeeService
                            .GetCargoesByEmployeeIdAsync(EmployeeId);

            return Ok(AddressesList);
        }

        [HttpGet("EmployeeIdOk")]
        public async Task<IActionResult> GetCargoesOkByEmployeeId([FromQuery(Name = "EmployeeIdOk")] int EmployeeId)
        {
            var AddressesList = await _manager
                            .EmployeeService
                            .GetCargoesOkByEmployeeIdAsync(EmployeeId);

            return Ok(AddressesList);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneEmployeeAsync([FromBody] EmployeeDtoForInsertion employeeDto)
        {
            var employee = await _manager.EmployeeService.CreateOneEmployeeAsync(employeeDto);
            return StatusCode(201, employee);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("id")]
        public async Task<IActionResult> UpdateOneEmployeeAsync([FromQuery(Name = "id")] int id, [FromBody] EmployeeDtoForUpdate employeeDto)
        {
            await _manager.EmployeeService.UpdateOneEmployeeAsync(id, employeeDto, false);
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteOneemployeeAsync([FromQuery(Name = "id")] int id)
        {
            await _manager.EmployeeService.DeleteOneEmployeeAsync(id, false);
            return NoContent();
        }

        [HttpPost("loginEmployee")]
        public async Task<IActionResult> UserLoginEmployee([FromBody] LoginRequestEmployee loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Alanlar boş bırakılamaz");
            }

            var isUserValid = await _manager.EmployeeService.UserLoginAsync(loginRequest.UserName, loginRequest.Password);

            if (isUserValid is not null)
            {
                return Ok(isUserValid);
            }
            else
            {
                return Unauthorized("Kullanıcı adı veya şifre hatalı.");
            }
        }

        public class LoginRequestEmployee
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
