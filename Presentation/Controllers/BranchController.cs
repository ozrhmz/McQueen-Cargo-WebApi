using Entities.DTO_s.Branch;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/branch")]
    public class BranchController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BranchController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet(Name = "GetAllBranchAsync")]
        public async Task<IActionResult> GetAllBranchesAsync([FromQuery] BranchParameters branchParameters)
        {
            var branches = await _manager.BranchService.GetAllBranchesAsync(branchParameters, false);
            return Ok(branches);
        }

        [HttpGet("BranchId")]
        public async Task<IActionResult> GetOneBranchAsync([FromQuery(Name = "id")] int id)
        {
            var branch = await _manager
                .BranchService
                .GetOneBranchByIdAsync(id, false);

            return Ok(branch);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneBranchAsync([FromBody] BranchDtoForInsertion branchDto)
        {
            var branch = await _manager.BranchService.CreateOneBracnhAsync(branchDto);
            return StatusCode(201, branch);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("UpdateBranchId")]
        public async Task<IActionResult> UpdateOneBranchAsync([FromQuery(Name = "id")] int id, [FromBody] BranchDtoForUpdate branchDto)
        {
            await _manager.BranchService.UpdateOneBranchAsync(id, branchDto, false);
            return NoContent(); //204
        }

        [HttpDelete("DeleteBranchId")]
        public async Task<IActionResult> DeleteOneBranchAsync([FromQuery(Name = "id")] int id)
        {
            await _manager.BranchService.DeleteOneBranchAsync(id, false);
            return NoContent();
        }
    }
}
