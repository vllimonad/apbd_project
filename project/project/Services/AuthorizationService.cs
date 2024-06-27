using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using project.Data;
using project.Models;
using project.Models.DTOs;

namespace project.Services;

public class AuthorizationService: IAuthorizationService
{
    private readonly ApplicationContext _context;
    private readonly IConfiguration _config;

    public AuthorizationService(ApplicationContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }
    
    public async Task Register(EmployeeDTO dto)
    {
        var hashedPasswordAndSalt = GetHashedPasswordAndSalt(dto.Password);

        var employee = new Employee()
        {
            Login = dto.Login,
            Role = "user",
            Password = hashedPasswordAndSalt.Item1,
            Salt = hashedPasswordAndSalt.Item2,
            RefreshToken = GenerateRefreshToken(),
            RefreshTokenExp = DateTime.Parse("2025-01-01")
        };

        if (_context.Employees.Any(u => u.Login.Equals(dto.Login))) throw new Exception("This login already exist");
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }
    
    public async Task<LoginResponseDTO> Login(EmployeeDTO dto)
    {
        if (! _context.Employees.Any(u => u.Login.Equals(dto.Login))) throw new Exception("This employee does not exist");
        
        Employee employee = _context.Employees.First(u => u.Login.Equals(dto.Login));
        var hashedPasswordWithSalt = GetHashedPasswordWithSalt(dto.Password, employee.Salt); 
        
        if (!hashedPasswordWithSalt.Equals(employee.Password)) throw new Exception("Wrong credentials");
        
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
        SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        Claim[] userclaim = new[]
        {
            new Claim(ClaimTypes.Name, employee.Login),
            new Claim(ClaimTypes.Role, employee.Role)
           
        };
        
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _config["JWT:Issuer"],
            audience: _config["JWT:Audience"],
            expires: DateTime.UtcNow.AddMinutes(2),
            signingCredentials: signingCredentials,
            claims: userclaim
        );
        
        
        var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
        
        var refreshToken = GenerateRefreshToken();
        employee.RefreshToken = refreshToken;
        employee.RefreshTokenExp = DateTime.Now.AddDays(3);
        await _context.SaveChangesAsync();
        return new LoginResponseDTO()
        {
            Token = stringToken,
            RefreshToken = refreshToken
        };
    }
    
    public Tuple<string, string> GetHashedPasswordAndSalt(string password)
    {
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        string saltBase64 = Convert.ToBase64String(salt);

        return new(hashed, saltBase64);
    }

    public string GetHashedPasswordWithSalt(string password, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);

        string currentHashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: saltBytes,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return currentHashedPassword;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}