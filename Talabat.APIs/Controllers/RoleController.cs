using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;

namespace Talabat.APIs.Controllers
{
    [Authorize("Admin")]
    public class RoleController : APIBaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost()]
        public async Task<ActionResult<RoleDto>> AddRole([FromForm] RoleDto role)
        {
            var isExist = await _roleManager.FindByNameAsync(role.Name) is not null ? true : false;
            if (isExist)
                return BadRequest(new ApiResponse(400, "This Role Is Arleady Exsit"));
            var result = await _roleManager.CreateAsync(new IdentityRole { Name = role.Name });
            if (!result.Succeeded)
                return BadRequest(new ApiResponse(400, result.Errors.Aggregate("", (fe, le) => fe + "\n" + le.Description).ToString()));
            return Ok(role);
        }

        [HttpPut()]
        public async Task<ActionResult<RoleDto>> UpdateRole(RoleDto role)
        {
            var isExist = await _roleManager.FindByIdAsync(role.Id) is not null ? true : false;
            if (!isExist)
                return BadRequest(new ApiResponse(400, "This Role Is Not Exsit"));
            var result = await _roleManager.UpdateAsync(new IdentityRole { Name = role.Name, Id = role.Id });
            if (!result.Succeeded)
                return BadRequest(new ApiResponse(400, result.Errors.Aggregate("", (fe, le) => fe + "\n" + le.Description).ToString()));
            return Ok(role);
        }

        [HttpGet("{id:string}")]
        public async Task<ActionResult<RoleDto>> GetById(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role is null)
                return BadRequest(new ApiResponse(400, "This Role Is Not Exsit"));
            return Ok(new RoleDto { Id = role.Id, Name = role.Name });
        }

        [HttpGet()]
        public async Task<ActionResult<List<RoleDto>>> GetAllRoles()
           => await _roleManager.Roles.Select(r => new RoleDto { Id = r.Id, Name = r.Name }).ToListAsync();
    }
}
