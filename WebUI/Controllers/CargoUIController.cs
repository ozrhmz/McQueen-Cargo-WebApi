using Microsoft.AspNetCore.Mvc;
using WebUI.Services;

namespace WebUI.Controllers
{
    public class CargoUIController : Controller
    {
        private readonly AuthenticationService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CargoUIController(AuthenticationService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
