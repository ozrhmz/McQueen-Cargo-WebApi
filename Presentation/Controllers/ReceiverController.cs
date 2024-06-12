using Entities.DTO_s.Receiver;
using Entities.RequestFeatures;
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
    [Route("api/receiver")]
    public class ReceiverController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public ReceiverController(IServiceManager manager, RepositoryContext context)
        {
            _manager = manager;
            _context = context;
        }

        [HttpGet(Name = "GetAllReceiverAsync")]
        public async Task<IActionResult> GetAllReceiversAsync([FromQuery] ReceiverParameters receiverParameters)
        {
            var receiver = await _manager.ReceiverService.GetAllReceiversAsync(receiverParameters, false);
            return Ok(receiver);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetOneReceiverAsync([FromQuery(Name = "id")] int id)
        {
            var receiver = await _manager
                .ReceiverService
                .GetOneReceiverByIdAsync(id, false);

            return Ok(receiver);
        }

        [HttpGet("CustomerMobilId")] //Bir müşterinin mobil id'sine göre receivers getirir.
        public async Task<IActionResult> GetAllReceiversWithCustomerMobilId([FromQuery(Name = "customerMobilId")] int customerMobilId)
        {
            return Ok(await _manager.ReceiverService.GetOneCustomerMobilIdWithReceiver(customerMobilId, false));
        }

        [HttpGet("CustomerId")] //Bir müşterinin id'sine göre receivers getirir.
        public async Task<IActionResult> GetAllReceiversWithCustomerId([FromQuery(Name = "customerId")] int customerId)
        {
            return Ok(await _manager.ReceiverService.GetOneCustomerIdWithReceiver(customerId, false));
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneReceiverAsync([FromBody] ReceiverDtoForInsertion receiverDto)
        {
            var receiver = await _manager.ReceiverService.CreateOneReceiverAsync(receiverDto);
            return StatusCode(201, receiver);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("id")]
        public async Task<IActionResult> UpdateOneReceiverAsync([FromQuery(Name = "id")] int id, [FromBody] ReceiverDtoForUpdate receiverDto)
        {
            await _manager.ReceiverService.UpdateOneReceiverAsync(id, receiverDto, false);
            return NoContent(); //204
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteOneReceiverAsync([FromQuery(Name = "id")] int id)
        {
            await _manager.ReceiverService.DeleteOneReceiverAsync(id, false);
            return NoContent();
        }

        [HttpDelete("deleteInactiveReceivers")]
        public async Task<IActionResult> DeleteInactiveReceivers()
        {
            try
            {
                await _manager.ReceiverService.DeleteInactiveReceiversAsync();
                return Ok("Inactive receivers deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
