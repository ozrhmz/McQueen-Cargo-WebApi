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
    [Route("api/district")]
    public class DistrictController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public DistrictController(RepositoryContext context, IServiceManager manager)
        {
            _context = context;
            _manager = manager;
        }

        [HttpGet(Name = "GetAllDistrictAsync")]
        public async Task<IActionResult> GetAllDistrictAsync()
        {
            var districts = await _manager.DistrictService.GetAllDistrict();
            return Ok(districts);
        }
    }
}
