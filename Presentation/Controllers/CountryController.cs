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
    [Route("api/country")]
    public class CountryController : ControllerBase
    {
        private readonly IServiceManager _manager;
        private readonly RepositoryContext _context;

        public CountryController(RepositoryContext context, IServiceManager manager)
        {
            _context = context;
            _manager = manager;
        }

        [HttpGet(Name = "GetAllCountriesAsync")]
        public async Task<IActionResult> GetAllCountriesAsync()
        {
            var countries = await _manager.CountryService.GetAllCountry();
            return Ok(countries);
        }
    }
}
