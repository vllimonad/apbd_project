using project.Models.DTOs;

namespace project.Services;

public interface IAuthorizationService
{
    Task Register(EmployeeDTO dto);
    Task<LoginResponseDTO> Login(EmployeeDTO dto);
    Tuple<string, string> GetHashedPasswordAndSalt(string password);
    string GetHashedPasswordWithSalt(string password, string salt);
    string GenerateRefreshToken();
}