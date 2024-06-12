using Entities.DTO_s.Cargo;
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
    [Route("api/cargo")]
    public class CargoController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public CargoController(IServiceManager manager, RepositoryContext context)
        {
            _manager = manager;
            _context = context;
        }

        [HttpGet(Name = "GetAllCargoAsync")]
        public async Task<IActionResult> GetAllCargoAsync()
        {
            var cargo = await _manager.CargoService.GetAllCargo();
            return Ok(cargo);
        }

        [HttpGet("GetAllCargoWithTcNo")]
        public async Task<IActionResult> GetAllCargoWithTcNoAsync([FromQuery] string tcNo)
        {
            var cargo = await _manager.CargoService.GetAllCargoByTCNoAsync(tcNo, false);
            return Ok(cargo);
        }

        [HttpGet("GetOneCargoWithTrackingNo")]
        public async Task<IActionResult> GetOneCargoWithTrackingNoAsync([FromQuery] string trackingNo)
        {
            var cargo = await _manager.CargoService.GetOneCargoByTrackingNoAsync(trackingNo, false);
            return Ok(cargo);
        }

        [HttpGet("GetOneCargoWithId")]
        public async Task<IActionResult> GetOneCargoWithId([FromQuery] int id)
        {
            var cargo = await _manager.CargoService.GetOneCargoByIdAsync(id, false);
            return Ok(cargo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneCargo([FromBody] CargoDtoForInsertion Cargo)
        {
            var cargo = await _manager.CargoService.CreateOneCargoAsync(Cargo);
            return StatusCode(201, cargo);
        }

        [HttpPut("CargoId")]
        public async Task<IActionResult> UpdateOneCustomerAsync([FromQuery(Name = "id")] int id, [FromBody] CargoDtoForUpdate cargoDto)
        {
            await _manager.CargoService.UpdateOneCargoAsync(id, cargoDto, false);
            return NoContent(); //204
        }
    }
}