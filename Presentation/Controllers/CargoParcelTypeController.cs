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
    [Route("api/cargoparceltype")]
    public class CargoParcelTypeController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public CargoParcelTypeController(RepositoryContext context, IServiceManager manager)
        {
            _context = context;
            _manager = manager;
        }

        [HttpGet(Name = "GetAllCargoParcelTypeAsync")]
        public async Task<IActionResult> GetAllCargoParcelTypeAsync()
        {
            var CargoParcelType = await _manager.CargoParcelTypeService.GetAllCargoParcelType();
            return Ok(CargoParcelType);
        }
    }
}
