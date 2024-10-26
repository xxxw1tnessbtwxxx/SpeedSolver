using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SpeedSolverCore.DTO.User;
using SpeedSolverDatabase.Models;

namespace SpeedSolverCore.JwtProvider;

public class JwtProvider
{
    public static readonly string KEY = "supersecretkeysupersecretkeysupersecretkey";
    public string GenerateJwtToken(User user)
    {
        
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY)), SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            signingCredentials: signingCredentials,
            expires: DateTime.Now.AddHours(24),
            claims: [new Claim("userId", user.UserId.ToString())]
            );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
        
    }
}