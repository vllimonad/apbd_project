using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
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
        if (_context.Employees.Any(u => u.Login.Equals(dto.Login))) 
            throw new Exception("This login already exist");

        var tuple = GetHashedPasswordAndSalt(dto.Password);
        var employee = new Employee()
        {
            Login = dto.Login,
            Role = "user",
            Password = tuple.Item1,
            Salt = tuple.Item2
        };

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<string> Login(EmployeeDTO dto)
    { 
        if (! await _context.Employees.AnyAsync(u => u.Login.Equals(dto.Login))) 
            throw new Exception("This employee does not exist");

        Employee employee = await _context.Employees.FirstAsync(u => u.Login.Equals(dto.Login));
        if (!GetHashedPasswordWithSalt(dto.Password, employee.Salt).Equals(employee.Password)) 
            throw new Exception("Wrong credentials");

        return await GenerateToken(employee);
    }
    
    
    public async Task<string> GenerateToken(Employee employee)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_config["JWT:Key"]);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, employee.Login),
                new Claim(ClaimTypes.Role, employee.Role)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public static Tuple<string, string> GetHashedPasswordAndSalt(string password)
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

    public static string GetHashedPasswordWithSalt(string password, string salt)
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
}