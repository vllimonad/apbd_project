using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Models.DTOs;
using IAuthorizationService = project.Services.IAuthorizationService;

namespace project.Controllers;

[ApiController]
[Route("api/authorization")]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthorizationService _service;

    public AuthorizationController(IAuthorizationService service)
    {
        _service = service;
    }

    [AllowAnonymous]
    [HttpPost("/register")]
    public async Task<IActionResult> Register(EmployeeDTO dto)
    {
        await _service.Register(dto);
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("/login")]
    public async Task<IActionResult> Login(EmployeeDTO dto)
    {
        var response = await _service.Login(dto);
        return Ok(response);
    }
    
}