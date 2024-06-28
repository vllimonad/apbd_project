using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project.Models.DTOs;
using project.Services;

namespace project.Controllers;

[ApiController]
[Route("api/authorization")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
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
        var token = await _service.Login(dto);
        return Ok("Token: " + token);
    }
}