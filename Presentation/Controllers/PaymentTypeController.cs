using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;


namespace Presentation.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/paymenttype")]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public PaymentTypeController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet(Name = "GetAllPaymentType")]
        public async Task<IActionResult> GetAllPaymentTypeAsync()
        {
            var paymentType = await _manager.PaymentTypeService.GetAllPaymentType();
            return Ok(paymentType);
        }
    }
}
