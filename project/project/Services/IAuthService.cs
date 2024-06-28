using Microsoft.IdentityModel.Tokens;
using project.Models.DTOs;

namespace project.Services;

public interface IAuthService
{
    Task Register(EmployeeDTO dto);
    Task<string> Login(EmployeeDTO dto);
}