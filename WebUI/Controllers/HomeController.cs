using Entities.DTO_s.Auth;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using WebUI.Filters;
using WebUI.Models;
using WebUI.Services;
using static Presentation.Controllers.EmployeeController;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AuthenticationService _service;
        private readonly HomeApiService _HomeService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, AuthenticationService service, HomeApiService homeService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _service = service;
            _HomeService = homeService;
            _httpContextAccessor = httpContextAccessor;
        }

        [LoginRequired]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Login()
        {
            var tokenResponse = await _service.Login();

            if (tokenResponse != null)
            {
                HttpContext.Session.SetString("AccessToken", tokenResponse.AccessToken);
                HttpContext.Session.SetString("RefreshToken", tokenResponse.RefreshToken);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre yanlış.");
                return View();
            }
        }

        public IActionResult LoginEmployeePage()
        {
            return View();
        }

        public async Task<IActionResult> LoginEmployee(LoginRequestEmployee Employee)
        {
            string accessToken = HttpContext.Session.GetString("AccessToken");
            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Login", "Home");

            var response = await _HomeService.LoginEmployee(Employee,accessToken);
            if (response == null)
                throw new Exception("Hatalı Kullanıcı Girişi Yapıldı");

            _httpContextAccessor.HttpContext.Session.SetString("UserId", response.Id.ToString());
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
