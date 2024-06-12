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
    [Route("api/neighbourhood")]
    public class NeighbourhoodController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public NeighbourhoodController(RepositoryContext context, IServiceManager manager)
        {
            _context = context;
            _manager = manager;
        }

        [HttpGet(Name = "GetAllNeighbourhoodsAsync")]
        public async Task<IActionResult> GetAllNeighbourhoodsAsync(int DistrictId)
        {
            var neigh = await _manager.NeighbourhoodService.GetAllNeighbourhood(DistrictId);
            return Ok(neigh);
        }
    }
}
