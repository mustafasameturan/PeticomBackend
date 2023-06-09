using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Services;

namespace Peticom.WebAPI.Controllers;

[Route("api/roles")]
[ApiController]
public class RolesController : BaseController
{

    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var roles = await _roleService.GetAllAsync();
        return Ok(roles);
    }

    [HttpGet("getRoleByName")]
    public async Task<IActionResult> GetRoleByName([FromQuery] string roleName)
    {
        return CreateActionResult(await _roleService.GetRoleByName((roleName)));
    }

    [HttpPost("add")]
    public async Task<IActionResult> CreateRole([FromBody] string roleName)
    {
        return CreateActionResult(await _roleService.CreateRoleAsync(roleName));
    }
}