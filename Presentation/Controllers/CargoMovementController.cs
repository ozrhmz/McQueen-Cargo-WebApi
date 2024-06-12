using Entities.DTO_s.CargoStatus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/cargomovement")]
    public class CargoMovementController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CargoMovementController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet(Name = "GetAllCargoMovementsAsync")]
        public async Task<IActionResult> GetAllCargoMovementsAsync()
        {
            var cargoMovements = await _manager.CargoMovementService.GetAllCargoMovement();
            return Ok(cargoMovements);
        }

        [HttpGet("CargoMovementId")]
        public async Task<IActionResult> GetOneCargoMovementByIdAsync([FromQuery(Name = "id")] int id)
        {
            var CargoMovement = await _manager.CargoMovementService.GetOneCargoMovementByIdAsync(id, false);
            return Ok(CargoMovement);
        }

        [HttpGet("CargoId")]
        public async Task<IActionResult> GetOneCargoMovementWithCargoByIdAsync([FromQuery(Name = "id")] int id)
        {
            var CargoMovement = await _manager.CargoMovementService.GetOneCargoMovementWithCargoByIdAsync(id, false);
            return Ok(CargoMovement);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneCargoMovementAsync([FromBody] CargoMovementDto cargoMovementDto)
        {
            var CargoMovement = await _manager.CargoMovementService.CreateOneCargoMovementAsync(cargoMovementDto);
            return StatusCode(201, CargoMovement);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("UpdateCargoMovementId")]
        public async Task<IActionResult> UpdateOneBranchAsync([FromQuery(Name = "id")] int id, [FromBody] CargoMovementDto cargoMovementDto)
        {
            await _manager.CargoMovementService.UpdateOneCargoMovementAsync(id, cargoMovementDto, false);
            return NoContent(); //204
        }

        [HttpDelete("DeleteCargoMovementId")]
        public async Task<IActionResult> DeleteOneBranchAsync([FromQuery(Name = "id")] int id)
        {
            await _manager.CargoMovementService.DeleteOneCargoMovementAsync(id, false);
            return NoContent();
        }
    }
}
