using Entities.DTO_s.CallCourier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Repositories.EFCore;
using Services.Contracts;

namespace Presentation.Controllers
{
    //[Authorize(Roles = "Admin,User")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/callcourier")]
    public class CallCourierController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public CallCourierController(IServiceManager manager, RepositoryContext context)
        {
            _manager = manager;
            _context = context;
        }

        [HttpGet(Name = "GetAllCourierAsync")]
        public async Task<IActionResult> GetAllCourierAsync()
        {
            var callCourier = await _manager.CallCourierService.GetAllCallCourier();
            return Ok(callCourier);
        }

        [HttpGet("CallCourierId")]
        public async Task<IActionResult> GetOneCallCourierWithById([FromQuery(Name = "callCourierId")] int id)
        {
            return Ok(await _manager.CallCourierService.GetOneCallCarierByIdAsync(id, false));
        }

        [HttpGet("TcNo")]
        public async Task<IActionResult> GetAllCourierWithByTcnoAsync([FromQuery] string tcNo)
        {
            var callCourier = await _manager.CallCourierService.GetAllCallCarierByTCNoAsync(tcNo, false);
            return Ok(callCourier);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("CreateOneCallCourier")]
        public async Task<IActionResult> CreateOneCallCourier([FromBody] CallCourierDtoForInsertion callCourierDto)
        {
            var cc = await _manager.CallCourierService.CreateOneCallCourierAsync(callCourierDto);
            return StatusCode(201, cc);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("UpdateCallCourierId")]
        public async Task<IActionResult> UpdateOneCallCourier([FromRoute(Name = "id")] int id,
            [FromBody] CallCourierDtoForUpdate callCourierDto)
        {
            await _manager.CallCourierService.UpdateOneCallCourierAsync(id, callCourierDto, false); //True ise değişkene atanıp kargo oluşturulacak.
            if (callCourierDto.CallCourierOk)
                await _manager.CargoService.CreateOneCargoForCallCourierAsync(callCourierDto);
            return NoContent();
        }

        [HttpDelete("DeleteCallCourierId")]
        public async Task<IActionResult> DeleteOneCallCourier([FromRoute(Name = "id")] int id)
        {
            await _manager.CallCourierService.DeleteOneCallCourierAsync(id, false);
            return NoContent();
        }
    }
}
