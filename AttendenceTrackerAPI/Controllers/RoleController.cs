using AttendanceTracker.Application.DTO.RoleDTO;
using AttendanceTracker.Application.Interface.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ISerivceRole _service;
        public RoleController(IServiceRole service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _service.GetAllRoles();
            return Ok(roles);
        }
        [HttpPut]
        public async Task<IActionResult> Update(RoleUpdateDTO dTO)
        {
            await _service.UpdateRole(dTO);
            return Ok("Role Deleted");
        }

    }
}
