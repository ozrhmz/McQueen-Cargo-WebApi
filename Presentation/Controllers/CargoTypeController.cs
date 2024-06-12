using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/cargotype")]
    public class CargoTypeController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CargoTypeController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet(Name = "GetAllCargoType")]
        public async Task<IActionResult> GetAllCargoTypeAsync()
        {
            var cargoType = await _manager.CargoTypeService.GetAllCargoType();
            return Ok(cargoType);
        }
    }
}
