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
    [Route("api/province")]
    public class ProvinceController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public ProvinceController(RepositoryContext context, IServiceManager manager)
        {
            _context = context;
            _manager = manager;
        }

        [HttpGet(Name = "GetAllProvincesAsync")]
        public async Task<IActionResult> GetAllProvincesAsync()
        {
            var provinces = await _manager.ProvinceService.GetAllProvince();
            return Ok(provinces);
        }
    }
}
