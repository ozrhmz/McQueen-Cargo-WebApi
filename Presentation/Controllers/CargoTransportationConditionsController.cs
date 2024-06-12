using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/cargotrancon")]
    public class CargoTransportationConditionsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CargoTransportationConditionsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet(Name = "GetAllCargoTransportationConditions")]
        public async Task<IActionResult> GetAllCargoTransportationConditionsAsync()
        {
            var cargoCon = await _manager.CargoTransportationConditions.GetAllCargoTransCon();
            return Ok(cargoCon);
        }
    }
}
