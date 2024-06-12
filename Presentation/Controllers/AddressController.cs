using Entities.DTO_s;
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
    [Route("api/addresses")]
    public class AddressController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly RepositoryContext _context;

        public AddressController(IServiceManager serviceManager, RepositoryContext context)
        {
            _serviceManager = serviceManager;
            _context = context;
        }
        [HttpGet] // Tüm adresleri getirir.
        public async Task<IActionResult> GetAllAddressesAsync([FromQuery] AddressParameters addressParameters)
        {
            return Ok(await _serviceManager.AddressService.GetAllAddressesAsync(addressParameters, false));
        }

        [HttpGet("customer")] // Bir müşterinin id'sine göre adres getirir.
        public async Task<IActionResult> GetAllAddressesWithCustomerId([FromQuery(Name = "customerId")] int customerId)
        {
            return Ok(await _serviceManager.AddressService.GetOneCustomerIdWithAddress(customerId, false));
        }

        [HttpGet("customerMobil")] // Bir müşterinin Mobil id'sine göre adres getirir.
        public async Task<IActionResult> GetAllAddressesWithCustomerMobilId([FromQuery(Name = "customerMobilId")] int customerMobilId)
        {
            return Ok(await _serviceManager.AddressService.GetOneCustomerMobilIdWithAddress(customerMobilId, false));
        }

        [HttpGet("branch")] // Bir branch'in id'sine göre adres getirir.
        public async Task<IActionResult> GetAllAddressesWithBranchId([FromQuery(Name = "branchId")] int branchId)
        {
            return Ok(await _serviceManager.AddressService.GetOneBranchIdWithAddress(branchId, false));
        }

        [HttpGet("address")] // Address id'sine göre adres getirir.
        public async Task<IActionResult> GetOneAddressByIdAsync([FromQuery(Name = "id")] int id)
        {
            return Ok(await _serviceManager.AddressService.GetOneAddressByIdAsync(id, false));
        }

        [HttpGet("addressByCustomer")] // Müşteri id ve Address id alarak adres getirir.
        public async Task<IActionResult> GetOneAddressWithCustomerIdAsync([FromQuery(Name = "addressId")] int addressId, [FromQuery(Name = "customerId")] int customerId)
        {
            return Ok(await _serviceManager.AddressService.GetOneAddressWithCustomerIdAsync(customerId, addressId, false));
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("CustomerId")] // Customer ile adres oluşturma
        public async Task<IActionResult> CreateOneAddressAsync([FromQuery] int customerId, [FromBody] AddressDtoForInsertion addressDto)
        {
            var validationMessages = addressDto.GetValidationMessages();
            if (validationMessages.Any())
            {
                return BadRequest(validationMessages);
            }
            var address = await _serviceManager.AddressService.CreateOneAddressAsync(addressDto, customerId);
            return StatusCode(201, address);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("BranchId")] // Branch ile adres oluşturma
        public async Task<IActionResult> CreateOneAddressBanchAsync([FromQuery] int branchId, [FromBody] AddressDtoForInsertion addressDto)
        {
            var validationMessages = addressDto.GetValidationMessages();
            if (validationMessages.Any())
            {
                return BadRequest(validationMessages);
            }
            var address = await _serviceManager.AddressService.CreateOneAddressBranchAsync(addressDto, branchId);
            return StatusCode(201, address);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("CustomerMobilId")] // CustomerMobil ile adres oluşturma
        public async Task<IActionResult> CreateOneAddressMobilAsync([FromQuery] int customerMobilId, [FromBody] AddressDtoForInsertion addressDto)
        {
            var validationMessages = addressDto.GetValidationMessages();
            if (validationMessages.Any())
            {
                return BadRequest(validationMessages);
            }
            var address = await _serviceManager.AddressService.CreateOneAddressMobilAsync(addressDto, customerMobilId);
            return StatusCode(201, address);
        }


        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("updateAddress")] // Adres güncelleme
        public async Task<IActionResult> UpdateOneAddressAsync([FromQuery(Name = "id")] int id, [FromBody] AddressDtoForUpdate addressDto)
        {
            var validationMessages = addressDto.GetValidationMessages();
            if (validationMessages.Any())
            {
                return BadRequest(validationMessages);
            }
            await _serviceManager.AddressService.UpdateOneAddressAsync(id, addressDto, false);
            return NoContent(); // 204
        }

        [HttpDelete("deleteAddress")] // Adres silme
        public async Task<IActionResult> DeleteOneAddressAsync([FromQuery(Name = "id")] int id)
        {
            await _serviceManager.AddressService.DeleteOneAddressAsync(id, false);
            return NoContent();
        }
    }
}
