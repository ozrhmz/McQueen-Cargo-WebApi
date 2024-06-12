using Entities.DTO_s;
using Microsoft.AspNetCore.Mvc;
using WebUI.Services;

namespace WebUI.Controllers
{
    public class CustomerUIController : Controller
    {
        private readonly CustomerApiServices _customerApiServices;

        public CustomerUIController(CustomerApiServices customerApiServices)
        {
            _customerApiServices = customerApiServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            string accessToken = TakeAccessToken();

            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Login", "Home");

            var customers = await _customerApiServices.GetAllAsync(accessToken);
            return View(customers);
        }

        public async Task<IActionResult> UpdateCustomer(int id)
        {
            string accessToken = TakeAccessToken();

            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Login", "Home");

            var customer = await _customerApiServices.GetCustomerByIdAsync(id,accessToken);
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(CustomerDto customer)
        {
            string accessToken = TakeAccessToken();
            if (ModelState.IsValid)
            {
                await _customerApiServices.UpdateCustomerAsync(customer,accessToken);
                return RedirectToAction(nameof(GetAllCustomers));
            }
            return View(customer);
        }


        public async Task<IActionResult> DeleteCustomer(int id)
        {
            string accessToken = TakeAccessToken();
            if (ModelState.IsValid)
            {
                await _customerApiServices.DeleteCustomerAsync(id, accessToken);
                return RedirectToAction(nameof(GetAllCustomers));
            }
            return View();
        }

        public string TakeAccessToken()
        {
            string accessToken = HttpContext.Session.GetString("AccessToken");
            return accessToken;
        }
    }
}
