using Entities.DTO_s;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.ActionFilters;
using Repositories.EFCore;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public CustomerController(IServiceManager manager, RepositoryContext context)
        {
            _manager = manager;
            _context = context;
        }

        [HttpGet(Name = "GetAllCustomerAsync")]
        public async Task<IActionResult> GetAllCustomersAsync([FromQuery] CustomerParameters customerParameters)
        {
            var customers = await _manager.CustomerService.GetAllCustomersAsync(customerParameters, false);
            return Ok(customers);
        }

        [HttpGet("CustomerId")]
        public async Task<IActionResult> GetOneCustomersAsync([FromQuery(Name = "id")] int id)
        {
            var customer = await _manager
                .CustomerService
                .GetOneCustomerByIdAsync(id, false);

            return Ok(customer);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneCustomerAsync([FromBody] CustomerDtoForInsertion customerDto)
        {
            var customer = await _manager.CustomerService.CreateOneCustomerAsync(customerDto);
            return StatusCode(201, customer);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("CustomerId")]
        public async Task<IActionResult> UpdateOneCustomerAsync([FromQuery(Name = "id")] int id, [FromBody] CustomerDtoForUpdate customerDto)
        {
            await _manager.CustomerService.UpdateOneCustomerAsync(id, customerDto, false);
            return NoContent(); //204
        }

        [HttpDelete("CustomerId")]
        public async Task<IActionResult> DeleteOneCustomerAsync([FromQuery(Name = "id")] int id)
        {
            await _manager.CustomerService.DeleteOneCustomerAsync(id, false);
            return NoContent();
        }

        [HttpPatch("CustomerId")]
        public async Task<IActionResult> PartiallyUpdateOneCustomerAsync([FromQuery(Name = "id")] int id,
            [FromBody] JsonPatchDocument<CustomerDtoForUpdate> customerPatch)
        {
            if (customerPatch is null)
                return BadRequest();

            var result = await _manager.CustomerService.GetOneCustomerForPatchAsync(id, false);

            customerPatch.ApplyTo(result.customerDtoForUpdate, ModelState);

            TryValidateModel(result.customerDtoForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _manager.CustomerService.SaveChangesForPatchAsync(result.customerDtoForUpdate, result.customer);

            return NoContent();//204
        }

        [HttpGet("TcNo")]
        public async Task<IActionResult> GetCustomerTCNoWithAddress([FromQuery(Name = "tcNo")] string tcNo)
        {
            var customer = await _manager.CustomerService.GetOneCustomerByTCNoAsync(tcNo, false);

            if (customer == null)
                return NotFound($"Customer {tcNo} is not found");

            var customerAddresses = await _context.CustomerAddress
                .Include(ca => ca.Address)
                .Where(ca => ca.CustomerId == customer.Id)
                .Select(ca => ca.Address)
                .ToListAsync();

            return Ok(customerAddresses);
        }
    }
}
