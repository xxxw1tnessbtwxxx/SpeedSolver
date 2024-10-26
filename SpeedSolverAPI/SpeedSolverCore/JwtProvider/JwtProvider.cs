using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SpeedSolverDatabase.Models;

namespace SpeedSolverCore.JwtProvider;

public class JwtProvider
{
    public string GenerateJwtToken(UserEntity user)
    {
        
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecretkeysupersecretkeysupersecretkey")), SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            signingCredentials: signingCredentials,
            expires: DateTime.Now.AddHours(24),
            claims: [new Claim("userId", user.UserId.ToString())]
            );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
        
    }
}