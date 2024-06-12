using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/cargostatus")]

    public class CargoStatusController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CargoStatusController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet(Name = "GetAllCargoStatus")]
        public async Task<IActionResult> GetAllCargoStatusAsync()
        {
            var cargoStatus = await _manager.CargoStatusService.GetAllCargoStatus();
            return Ok(cargoStatus);
        }
    }
}
