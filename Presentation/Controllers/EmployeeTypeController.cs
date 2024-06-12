using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Repositories.EFCore;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/employeetype")]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public EmployeeTypeController(RepositoryContext context, IServiceManager manager)
        {
            _context = context;
            _manager = manager;
        }

        [HttpGet(Name = "GetAllEmployeeTypeAsync")]
        public async Task<IActionResult> GetAllEmployeeTypeAsync()
        {
            var employeeType = await _manager.EmployeeTypeService.GetAllEmployeeType();
            return Ok(employeeType);
        }
    }
}
