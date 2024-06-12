using Entities.DTO_s.CustomerMobil;
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
    [Route("api/customerMobil")]

    public class CustomerMobilController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public CustomerMobilController(RepositoryContext context, IServiceManager manager)
        {
            _context = context;
            _manager = manager;
        }

        [HttpGet(Name = "GetAllCustomerMobilAsync")]
        public async Task<IActionResult> GetAllCustomerMobilAsync([FromQuery] CustomerMobilParameters customerMobilParameters)
        {
            var customers = await _manager.CustomerMobilService.GetAllCustomersAsync(customerMobilParameters, false);
            return Ok(customers);
        }

        [HttpGet("GetOneCustomerId")]
        public async Task<IActionResult> GetOneCustomerMobilAsync([FromQuery(Name = "id")] int id)
        {
            var customer = await _manager
                .CustomerMobilService
                .GetOneCustomerByIdAsync(id, false);

            return Ok(customer);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneCustomerMobilAsync([FromBody] CustomerMobilDtoForInsertion customerDto)
        {
            var validationMessages = customerDto.GetValidationMessages();
            if (validationMessages.Any())
            {
                return BadRequest(validationMessages);
            }

            var customer = await _manager.CustomerMobilService.CreateOneCustomerAsync(customerDto);
            return StatusCode(201, customer);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("id")]
        public async Task<IActionResult> UpdateOneCustomerAsync([FromQuery(Name = "id")] int id, [FromBody] CustomerMobilDtoForUpdate customerDto)
        {
            var validationMessages = customerDto.GetValidationMessages();
            if (validationMessages.Any())
            {
                return BadRequest(validationMessages);
            }
            await _manager.CustomerMobilService.UpdateOneCustomerAsync(id, customerDto, false);
            return NoContent(); //204
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteOneCustomerAsync([FromQuery(Name = "id")] int id)
        {
            await _manager.CustomerMobilService.DeleteOneCustomerAsync(id, false);
            return NoContent();
        }

        [HttpPatch("id")]
        public async Task<IActionResult> PartiallyUpdateOneCustomerMobilAsync([FromQuery(Name = "id")] int id,
            [FromBody] JsonPatchDocument<CustomerMobilDtoForUpdate> customerPatch)
        {
            if (customerPatch is null)
                return BadRequest();

            var result = await _manager.CustomerMobilService.GetOneCustomerForPatchAsync(id, false);

            customerPatch.ApplyTo(result.customerMobilDtoForUpdate, ModelState);

            TryValidateModel(result.customerMobilDtoForUpdate);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _manager.CustomerMobilService.SaveChangesForPatchAsync(result.customerMobilDtoForUpdate, result.customerMobil);

            return NoContent();//204
        }

        [HttpGet("GetCustomerIdWithAdress")]
        public async Task<IActionResult> GetCustomerIdWithAddress([FromQuery(Name = "id")] int id)
        {
            var customer = await _manager.CustomerMobilService.GetOneCustomerByIdAsync(id, false);

            if (customer == null)
                return NotFound($"Customer {id} is not found");

            var customerAddresses = await _context.CustomerAddress
                .Include(ca => ca.Address)
                .Where(ca => ca.CustomerMobilId == customer.Id)
                .Select(ca => ca.Address)
                .ToListAsync();

            return Ok(customerAddresses);
        }

        [HttpPost("login")]
        public async Task<IActionResult> UserLogin([FromBody] LoginRequest loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Alanlar boş bırakılamaz");
            }

            var isUserValid = await _manager.CustomerMobilService.UserLoginAsync(loginRequest.UserName, loginRequest.Password);

            if (isUserValid is not null)
            {
                return Ok(isUserValid);
            }
            else
            {
                return Unauthorized("Kullanıcı adı veya şifre hatalı.");
            }
        }

        [HttpPut("ForgotPassword")]
        public async Task<IActionResult> ForgotPasswordCustomerMobil([FromQuery] string Email, [FromQuery] string Tcno, [FromQuery] string newPassword)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Tcno))
                return BadRequest("E-Mail boş bırakılamaz.");

            var isUserValid = await _manager.CustomerMobilService.ForgotPasswordCustomerMobil(Email, newPassword);
            if (isUserValid is not null && isUserValid.TcNo == Tcno)
            {
                return Ok(isUserValid);
            }
            else
            {
                return NotFound("Hatalı bilgi girişi yaptınız.");
            }
        }

        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> UpdateCustomerMobilPassword([FromQuery] int customerMobilId, [FromQuery] string oldPassword, [FromQuery] string newPassword)
        {
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
            {
                return BadRequest("Alanlar boş bırakılamaz");
            }

            var isUserValid = await _manager.CustomerMobilService.UserUpdatePasswordAsync(customerMobilId, oldPassword, newPassword);

            if (isUserValid is not null)
            {
                return Ok(isUserValid);
            }
            else
            {
                return Unauthorized("Hatalı şifre girişi yaptınız.");
            }
        }

        public class LoginRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
